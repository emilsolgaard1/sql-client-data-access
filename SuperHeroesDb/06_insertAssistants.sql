INSERT INTO Assistant (Name, SuperheroId)
VALUES ('Bobin', (SELECT Id from Superhero WHERE Name='Hatman'));

INSERT INTO Assistant (Name, SuperheroId)
VALUES ('Hatgirl', (SELECT Id from Superhero WHERE Name='Hatman'));

INSERT INTO Assistant (Name, SuperheroId)
VALUES ('Eatt A. Candy', (SELECT Id from Superhero WHERE Name='Wander woman'));