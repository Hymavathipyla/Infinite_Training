

Create database Techmart;

Create table customers1( 
    CustID INT PRIMARY KEY, 
    CustName VARCHAR(100), 
    Email VARCHAR(200), 
    City VARCHAR(100) 
);

Insert into customers1 (CustID, CustName, Email, City) VALUES
(1, 'Amit Sharma', 'amit.sharma@gmail.com', 'Mumbai'),
(2, 'Ravi Kumar', 'ravi.kumar@yahoo.com', 'Delhi'),
(3, 'Priya Singh', 'priya.singh@gmail.com', 'Pune'),
(4, 'John Mathew', 'john.mathew@hotmail.com', 'Bangalore'),
(5, 'Sara Thomas', 'sara.thomas@gmail.com', 'Kochi'),
(6, 'Nidhi Jain', 'nidhi.jain@gmail.com', NULL);


Create table  Products( 
    ProductID INT PRIMARY KEY, 
    ProductName VARCHAR(100), 
    Price DECIMAL(10,2), 
    Stock INT CHECK(Stock >= 0) 
);

Insert into  Products (ProductID, ProductName, Price, Stock) VALUES
(101, 'Laptop Pro 14', 75000, 15),
(102, 'Laptop Air 13', 55000, 8),
(103, 'Wireless Mouse', 800, 50),
(104, 'Mechanical Keyboard', 3000, 20),
(105, 'USB-C Charger', 1200, 5),
(106, '27-inch Monitor', 18000, 10),
(107, 'Pen Drive 64GB', 600, 80);

Create table Orders( 
    OrderID INT PRIMARY KEY, 
    CustID INT FOREIGN KEY REFERENCES customers1(CustID), 
    OrderDate DATE, 
    Status VARCHAR(20) 
) ;

Insert into  Orders (OrderID, CustID, OrderDate, Status) VALUES
(5001, 1, '2025-01-05', 'Pending'),
(5002, 2, '2025-01-10', 'Completed'),
(5003, 1, '2025-01-20', 'Completed'),
(5004, 3, '2025-02-01', 'Pending'),
(5005, 4, '2025-02-15', 'Completed'),
(5006, 5, '2025-02-18', 'Pending');


Create table OrderDetails( 
    DetailID INT PRIMARY KEY, 
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID), 
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID), 
    Qty INT CHECK(Qty > 0) 
);

Insert into  OrderDetails (DetailID, OrderID, ProductID, Qty) VALUES
(9001, 5001, 101, 1),
(9002, 5001, 103, 2),
 
(9003, 5002, 104, 1),
(9004, 5002, 103, 1),
 
(9005, 5003, 102, 1),
(9006, 5003, 105, 1),
(9007, 5003, 103, 3),
 
(9008, 5004, 106, 1),
 
(9009, 5005, 107, 4),
(9010, 5005, 104, 1),
 
(9011, 5006, 101, 1),
(9012, 5006, 107, 2);

Create table Payments( 
    PaymentID INT PRIMARY KEY, 
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID), 
    Amount DECIMAL(10,2), 
    PaymentDate DATE 
);

Insert into Payments (PaymentID, OrderID, Amount, PaymentDate) VALUES
(7001, 5002, 3300, '2025-01-11'),
(7002, 5003, 62000, '2025-01-22'),
(7003, 5005, 4500, '2025-02-16');

select * from customers1;
select * from Products;
select * from Orders;
select * from OrderDetails;
select * from Payments;

--------------------------------------------------------------------------------

-------------SQL QUERIES-----------

--1--
Select Distinct c.CustID, c.CustName, c.Email, c.City
From customers1 AS c
Join Orders AS o ON o.CustID = c.CustID
Where  o.OrderDate >= '2025-01-01';

--2--
Select top 3 
       p.Productid, 
       p.Productname,
       sum(Qty * p.Price) as totalsales
From Products p
Join Orderdetails od 
  On od.Productid = p.Productid
Group By p.Productid, p.Productname
Order By totalsales desc;

--3--
Select 
    c.City,
    Count(Distinct c.Custid) as Customercount,
    Count(o.orderid) as Ordercount
From customers1 c
Left Join Orders o 
  On o.Custid = c.Custid
Group By c.City;

--4--
Select Orderid
From Orderdetails
Group By Orderid
Having Count(Distinct Productid) > 2;

--5--
Select Orderid,
       sum(Qty * p.Price) as totalamount
From Orderdetails o
Join Products p 
  On p.Productid = o.Productid
Group By Orderid
Having sum(Qty * p.Price) > 10000;

--6--
Select c.Custid,
       c.Custname,
       p.Productid,
       p.Productname
From customers1 c
Join Orders o 
  on o.Custid = c.Custid
Join Orderdetails od 
  on od.Orderid = o.Orderid
Join Products p 
  On p.Productid = od.Productid
Group By c.Custid, c.CustName, p.Productid, p.Productname
Having Count(*) > 1;

--7--

Alter Table  Orders Add Employeeid INT;

Update Orders SET Employeeid = 101 Where Orderid IN (5001, 5003, 5006);
Update Orders SET Employeeid = 102 Where Orderid IN (5002, 5005);
UPdate Orders SET Employeeid = 103 Where Orderid = 5004;

Select o.Employeeid,Count(o.Orderid) as totalorders,
sum(case when o.status = 'completed' then 1 else 0 end) as completedorders,
sum(case when o.status = 'pending' then 1 else 0 end) as pendingorders
From Orders o Group By o.Employeeid;

---Views---

Create View vw_LowStockProducts
WITH SCHEMABINDING, ENCRYPTION
As
Select p.Productid,
       p.Productname,
       p.Price,
       p.Stock
From dbo.Products AS p
Where p.Stock < 5;

Select * from vw_LowStockProducts;

--Functions--

Create Function fn_GetCustomerOrderHistory (@CustID INT)
Returns table 
AS
Return
(
    Select  o.Orderid,
           o.Orderdate,
           Sum (od.qty * p.price) AS totalamount
    From dbo.Orders o
    Join dbo.Orderdetails od 
      On od.Orderid = o.orderid
    Join dbo.Products p 
      On p.Productid = od.Productid
    Where o.Custid = @CustID
    Group By o.Orderid, o.Orderdate
);

Select * from fn_GetCustomerOrderHistory(1);


Create Function fn_getcustomerlevel (@custid int)returns varchar(20) as
Begin
declare @total decimal(18,2);
select @total = sum(od.Qty * p.price) from Orders o
Join Orderdetails od on o.Orderid = od.Orderid
Join Products p on od.Productid = p.Productid where o.Custid = @Custid;
if @total > 100000 Return 'platinum';
if @total >= 50000 Return 'gold';
Return 'silver';
End;
 
select dbo.fn_getcustomerlevel(1) AS customerlevel;


-----Procedures----

Create table PriceHistory (
    Historyid INT IDENTITY(1,1) PRIMARY KEY,
    Productid INT NOT NULL,
    Oldprice DECIMAL(18,2) NOT NULL,
    Changedate DATETIME NOT NULL DEFAULT GETDATE()
);

create procedure sp_updateprice
    @Productid int,
    @newprice decimal(10,2)
AS
Begin
    if @newprice <= 0
        raiserror('new price must be greater than zero', 16, 1);
    else if not exists (select 1 from Products where Productid = @Productid)
        raiserror('invalid product id', 16, 1);
    else
        update Products set price = @newprice where Productid = @Productid;
End;

EXEC dbo.sp_updateprice @Productid = 101, @newprice = 80000;

------------------------------------------------------------------------------------

Create or Alter procedure sp_searchorders
    @Custname varchar(100) = null,
    @City varchar(100) = null,
    @Productname varchar(100) = null,
    @Startdate date = null,
    @Enddate date = null
As
Begin
    select o.Orderid, c.CustName, c.City, o.Orderdate, p.Productname
    from Orders o
    Join customers1 c on o.Custid = c.Custid
    Join Orderdetails od on o.Orderid = od.Orderid
    Join Products p on od.Productid = p.Productid
    where (@CustName is null or c.CustName like '%' + @CustName + '%')
      and (@City is null or c.City = @City)
      and (@Productname is null or p.Productname like '%' + @Productname + '%')
      and (@Startdate is null or o.Orderdate >= @Startdate)
      and (@Enddate is null or o.Orderdate <= @Enddate);
End;




---------Triggers-----------
---1----
Create Trigger trg_PreventProductDelete
On dbo.Products
Instead of Delete 
As
Begin 
If Exists  (
        Select 1
        From  deleted d
        Join  dbo.Orderdetails od 
        On d.Productid = od.Productid
    )
    Begin 
        Raiserror('Cannot delete product. It is referenced in OrderDetails.', 16, 1);
        Rollback Transaction; 
    End
    Else
    Begin
        Delete from  dbo.Products
        Where Productid IN (select Productid from deleted);
    End
End;

DELETE FROM dbo.products WHERE productid = 999;

---2----

Create table  PaymentAudit (
    Auditid INT IDENTITY(1,1) PRIMARY KEY,
    Paymentid INT NOT NULL,
    Oldamount DECIMAL(18,2),
    Newamount DECIMAL(18,2),
    Changedate DATETIME NOT NULL DEFAULT GETDATE()
);

Create Trigger trg_PaymentAudit
On dbo.Payments
After Update
As
Begin
    Insert into PaymentAudit (Paymentid, Oldamount, Newamount)
    select  d.Paymentid,
           d.Amount,
           i.Amount
    from deleted d
    Join  inserted i 
    On d.paymentid = i.paymentid;
End;

update dbo.payments
set amount = amount + 100, paymentdate = dateadd(day, 1, paymentdate)
where paymentid = 7002;

SELECT * FROM PaymentAudit;

-----3-----

Create Trigger trg_CustomerDelete
On dbo.customers1
Instead of Delete 
AS
Begin 
       Update c
    Set c.status = 'Inactive'
    from  dbo.customers1 c
    Join  deleted d 
      On c.Custid = d.Custid
    Where Exists (
       select  1 
       from  dbo.Orders o 
       where o.Custid = d.Custid
    );

    Delete  From  dbo.customers1
    Where  Custid IN (
        Select  d.Custid
        From deleted d
        Where NOT EXISTS (
            Select 1 
            From dbo.Orders o 
            Where o.Custid = d.Custid
        )
    );
END;

insert into customers1(Custid, CustName, Email, City) values(9999,'Hyma','Hyma@gmail.com','hyd');

DELETE FROM dbo.customers1 WHERE Custid = 1;

DELETE FROM dbo.customers1 WHERE Custid = 9999;

ALTER TABLE dbo.customers1
ADD status VARCHAR(20) DEFAULT 'Active';

SELECT Custid, CustName, Email, City, status
FROM dbo.customers1;












