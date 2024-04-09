# Write your MySQL query statement below
SELECT Name as Customers 
FROM (Customers LEFT OUTER JOIN Orders on Customers.id = Orders.customerId)
WHERE CustomerId is null
