UPDATE 'Players' as 'p'
SET birthday = substr('p'.'BirthDay', 7) || '-' || substr('p'.'BirthDay', 4,2) || '-' || substr('p'.'BirthDay', 1,2)