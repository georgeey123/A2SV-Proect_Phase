# Write your MySQL query statement below
SELECT name as Employee FROM Employee e 
WHERE salary > (SELECT salary from Employee WHERE id=e.managerId)