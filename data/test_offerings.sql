USE [goodboydb]
GO

SELECT TOP (1000) [Id]
      ,[Name]
      ,[Description]
      ,[Quantity]
      ,[Price]
  FROM [goodboydb].[dbo].[Offerings]
;

INSERT INTO [dbo].[Offerings] ([Name], [Description], [Quantity], [Price]) VALUES
('Pillow Shredder', 'Meet Chompy, the ultimate pillow destroyer!', 5, 150.00),
('Professional Cuddler', 'Rent Snuggles, the cuddle champion!', 3, 200.00),
('Barking Mad', 'Introducing Howler, the acoustic tester!', 7, 100.00),
('Canine Therapist', 'Dr. Woof is here for your emotional support!', 2, 300.00),
('Scratching Post Pro', 'Scratchy McScratchface, the itch reliever!', 4, 120.00),
('Agility Ace', 'Zoom, the speed demon, for your sporting needs!', 6, 250.00),
('Muddy Paws', 'Get dirty with Mudslide, the mud enthusiast!', 8, 80.00),
('Drool Monster', 'Slobbers McGee, the drool expert!', 3, 50.00),
('Professional Sniffer', 'Sherlock Bones, the nose with the knows!', 1, 500.00),
('Hairy Houdini', 'Escape artist extraordinaire, Houdini the Hound!', 2, 400.00),
('Barking Maestro', 'Beethoven the Beagle, for your musical needs!', 5, 180.00),
('Professional Digger', 'Holes McGee, the excavation expert!', 4, 130.00),
('Canine Comedian', 'Chuckles the Clown, guaranteed to make you laugh!', 6, 220.00),
('Frisbee Fanatic', 'Catcher the Collie, frisbee champion!', 7, 110.00),
('Professional Napper', 'Sleepy the Sloth, master of relaxation!', 3, 70.00),
('Treat Tester', 'Taster the Terrier, connoisseur of treats!', 8, 90.00),
('Ball Obsessed', 'Fetchy McFetchface, ball retrieval expert!', 5, 140.00),
('Professional Pouncer', 'Pounce the Puma, master of surprise attacks!', 2, 350.00),
('Canine Cuddle Buddy', 'Huggy the Husky, warm and cuddly!', 4, 170.00),
('Barking Alarm Clock', 'Wakey the Waker, guaranteed to get you up!', 6, 210.00),
('Mud Wrestling Champion', 'Muddy the Mutt, for all your mud-wrestling needs!', 7, 100.00),
('Professional Shedder', 'Fluffy the Furball, shedding expert!', 3, 60.00),
('Canine Choreographer', 'Twirls the Terrier, dance instructor extraordinaire!', 8, 190.00),
('Barking Translator', 'Whisper the Interpreter, understands all barks!', 5, 240.00),
('Professional Beggar', 'Gimme the Great Dane, master of puppy-dog eyes!', 2, 450.00),
('Canine Lifeguard', 'Splash the Labrador, water safety expert!', 4, 160.00),
('Barking Mailman', 'Deliverance the Doberman, delivers with a bark!', 6, 200.00),
('Professional Snuggler', 'Cozy the Collie, cuddle enthusiast!', 7, 120.00),
('Canine Chef', 'Chef the Chow Chow, culinary canine!', 3, 80.00);