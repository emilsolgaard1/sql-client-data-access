INSERT INTO Power (Name, Description)
VALUES ('Pyrosis', 'The ability to emit flames from your boooooody.');

INSERT INTO Power (Name, Description)
VALUES ('Flight', 'The ability to invalidate gravity.');

INSERT INTO Power (Name, Description)
VALUES ('Superhuman strength', 'The ability to lift a heavy thing.');

INSERT INTO Power (Name, Description)
VALUES ('Eye Lasers', 'The ability to emit Light Amplification through Stimulated Emission of Radiation from the eyes.');



INSERT INTO SuperheroPowers (SuperheroId, PowerId)
VALUES ((SELECT Id from Superhero WHERE Name='Duperman'), (SELECT Id from Power WHERE Name='Flight'));

INSERT INTO SuperheroPowers (SuperheroId, PowerId)
VALUES ((SELECT Id from Superhero WHERE Name='Duperman'), (SELECT Id from Power WHERE Name='Superhuman strength'));

INSERT INTO SuperheroPowers (SuperheroId, PowerId)
VALUES ((SELECT Id from Superhero WHERE Name='Duperman'), (SELECT Id from Power WHERE Name='Eye Lasers'));

INSERT INTO SuperheroPowers (SuperheroId, PowerId)
VALUES ((SELECT Id from Superhero WHERE Name='Wander woman'), (SELECT Id from Power WHERE Name='Flight'));

INSERT INTO SuperheroPowers (SuperheroId, PowerId)
VALUES ((SELECT Id from Superhero WHERE Name='Wander woman'), (SELECT Id from Power WHERE Name='Superhuman strength'));