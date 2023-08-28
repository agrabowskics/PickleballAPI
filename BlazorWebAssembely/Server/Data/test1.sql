SELECT *
FROM "Players" AS "p"
WHERE CAST(strftime("%Y", "now") as INTEGER) - CAST(substr("p"."Birthday", 7) AS INTEGER) = 26 
AND CAST(strftime("%Y", "now") as INTEGER) - CAST(substr("p"."Birthday", 1, 2) AS INTEGER) >=0
AND CAST(substr("p"."Birthday", 4, 5) AS INTEGER) > 23