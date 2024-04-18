USE [UpVoteDb]

INSERT INTO Users([Nickname], [Password], [CreationDate])
VALUES ('_Noob_', 'noobkiller', '2015-05-05'),
	   ('_Nobo_', 'noobkille', '2013-04-22'),
	   ('_Nobb_', 'noobkill', '2018-10-18'),
	   ('_Nbob_', 'noobkil', '2012-12-31'),
	   ('_Nbbo_', 'noobki', '2016-01-01')

INSERT INTO Discussions([Name])
VALUES ('Why my dog is barking at night?'),
	   ('Cats get frightened when I get near them'),
	   ('My friends pranked me on my birthday'), ('Why do pranks exist?'),
	   ('Best recipe for plov'),
	   ('Help me get the name of this spice')

INSERT INTO UsersDiscussions([UserId], [DiscussionId])
VALUES (1, 1), (2, 1), (3, 1), (2, 2), (4, 2), (5, 2), (1, 3), (2, 3), (5, 3)

INSERT INTO Sections([Name], [CreationDate])
VALUES ('Animals', '2011-12-15'), ('Pranks', '2017-04-11'), ('Cooking', '2016-01-20')

INSERT INTO DiscussionsSections([SectionId], [DiscussionId])
VALUES (1, 1), (1, 2), (2, 3), (2, 4), (3, 5), (3, 6)