Api http://localhost:5153/swagger/index.html

Задание 2

1.
SELECT 
    c.ClientName,
    COUNT(cc.Id) AS ContactCount
FROM 
    Clients c
LEFT JOIN 
    ClientContacts cc ON c.Id = cc.ClientId
GROUP BY 
    c.Id, c.ClientName
ORDER BY 
    c.ClientName;


2.
SELECT 
    c.ClientName,
    COUNT(cc.Id) AS ContactCount
FROM 
    Clients c
JOIN 
    ClientContacts cc ON c.Id = cc.ClientId
GROUP BY 
    c.Id, c.ClientName
HAVING 
    COUNT(cc.Id) > 2
ORDER BY 
    COUNT(cc.Id) DESC;

Задание 3
WITH OrderedDates AS (
    SELECT 
        Id,
        Dt,
        LEAD(Dt) OVER (PARTITION BY Id ORDER BY Dt) AS NextDt
    FROM Dates
)
SELECT 
    Id,
    Dt AS Sd,
    NextDt AS Ed
FROM OrderedDates
WHERE NextDt IS NOT NULL
ORDER BY Id, Sd;
