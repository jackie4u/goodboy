USE [goodboydb]
GO

SELECT *
  FROM dbo.Products AS P
;

--TRUNCATE TABLE dbo.Products

INSERT INTO [dbo].[Products] ([Id], [Ean], [Name], [Description], [Quantity], [Currency], [Price], [Categories], [MainPicture]) VALUES
(1, '1234567890123', 'Pillow Shredder', 'Meet Chompy, the ultimate pillow destroyer! He''s got sharp teeth and a passion for fluff.', 5, 'CZK', 150.00, 'Destroy', 'https://images.unsplash.com/photo-1543329047-7a4877a17458'),
(2, '9876543210987', 'Professional Cuddler', 'Rent Snuggles, the cuddle champion! He''s a fluffy cloud of warmth and affection.', 3, 'CZK', 200.00, 'Cuddle', 'https://images.unsplash.com/photo-1600035975934-9df786602180'),
(3, '5678901234567', 'Barking Mad', 'Introducing Howler, the acoustic tester! He''ll bark at anything and everything.', 7, 'CZK', 100.00, 'Bark', 'https://images.unsplash.com/photo-1547425260-76bcadfb4f46'),
(4, '4321098765432', 'Canine Therapist', 'Dr. Woof is here for your emotional support! He''s a good listener and a great hugger.', 2, 'CZK', 300.00, 'Therapy', 'https://images.unsplash.com/photo-1571868094976-6edc94d86d52'),
(5, '8901234567890', 'Scratching Post Pro', 'Scratchy McScratchface, the itch reliever! He''ll scratch anything you need scratched.', 4, 'CZK', 120.00, 'Scratch', 'https://images.unsplash.com/photo-1568572330216-22c7458513cf'),
(6, '3210987654321', 'Agility Ace', 'Zoom, the speed demon, for your sporting needs! He''s fast, agile, and loves to run.', 6, 'CZK', 250.00, 'Sport', 'https://images.unsplash.com/photo-1596494999948-209c9084a349'),
(7, '7890123456789', 'Muddy Paws', 'Get dirty with Mudslide, the mud enthusiast! He''ll roll in anything you point him at.', 8, 'CZK', 80.00, 'Mud', 'https://images.unsplash.com/photo-1574678617049-1abb590a8a99'),
(8, '2109876543210', 'Drool Monster', 'Slobbers McGee, the drool expert! He''ll leave a trail of slobber wherever he goes.', 3, 'CZK', 50.00, 'Drool', 'https://images.unsplash.com/photo-1548199973-03cce0bbc87b'),
(9, '6543210987654', 'Professional Sniffer', 'Sherlock Bones, the nose with the knows! He can sniff out anything you need.', 1, 'CZK', 500.00, 'Sniff', 'https://images.unsplash.com/photo-1581796946711-ec51c22c9861'),
(10, '0987654321098', 'Hairy Houdini', 'Escape artist extraordinaire, Houdini the Hound! He can escape from any enclosure.', 2, 'CZK', 400.00, 'Escape', 'https://images.unsplash.com/photo-1541873676-4226803a6a85'),
(11, '9876543210123', 'Barking Maestro', 'Beethoven the Beagle, for your musical needs! He''ll howl along to any tune.', 5, 'CZK', 180.00, 'Music', 'https://images.unsplash.com/photo-1575387619663-5d455c2160c2'),
(12, '8765432109876', 'Professional Digger', 'Holes McGee, the excavation expert! He''ll dig you a hole to China if you let him.', 4, 'CZK', 130.00, 'Dig', 'https://images.unsplash.com/photo-1611799306057-830e70900a7a'),
(13, '7654321098765', 'Canine Comedian', 'Chuckles the Clown, guaranteed to make you laugh! He''s got more jokes than fleas.', 6, 'CZK', 220.00, 'Comedy', 'https://images.unsplash.com/photo-1517849845537-4d257902454a'),
(14, '6543210987654', 'Frisbee Fanatic', 'Catcher the Collie, frisbee champion! He''ll catch anything you throw, even your bad moods.', 7, 'CZK', 110.00, 'Frisbee', 'https://images.unsplash.com/photo-1574144947992-9fa686960630'),
(15, '5432109876543', 'Professional Napper', 'Sleepy the Sloth, master of relaxation! He''ll teach you the art of the perfect nap.', 3, 'CZK', 70.00, 'Nap', 'https://images.unsplash.com/photo-1547972446-7f1d3a188870'),
(16, '4321098765432', 'Treat Tester', 'Taster the Terrier, connoisseur of treats! He''ll give you his expert opinion on any snack.', 8, 'CZK', 90.00, 'Treat', 'https://images.unsplash.com/photo-1560807707-8cc77767d783'),
(17, '3210987654321', 'Ball Obsessed', 'Fetchy McFetchface, ball retrieval expert! He''ll fetch till he drops (the ball, not himself).', 5, 'CZK', 140.00, 'Fetch', 'https://images.unsplash.com/photo-1591495947118-700a39a490f0'),
(18, '2109876543210', 'Professional Pouncer', 'Pounce the Puma, master of surprise attacks! He''ll pounce on anything that moves (or doesn''t).', 2, 'CZK', 350.00, 'Pounce', 'https://images.unsplash.com/photo-1567529684892-09290a1b2d05'),
(19, '1098765432109', 'Canine Cuddle Buddy', 'Huggy the Husky, warm and cuddly! He''s like a furry hot water bottle.', 4, 'CZK', 170.00, 'Cuddle', 'https://images.unsplash.com/photo-1612195775746-bff18e5e99f1'),
(20, '0987654321098', 'Barking Alarm Clock', 'Wakey the Waker, guaranteed to get you up! He''ll bark until you''re out of bed.', 6, 'CZK', 210.00, 'Bark', 'https://images.unsplash.com/photo-1546456073-6712f79251bb'),
(21, '1234567890128', 'Mud Wrestling Champion', 'Muddy the Mutt, for all your mud-wrestling needs! He''s undefeated (and loves getting dirty).', 7, 'CZK', 100.00, 'Mud', 'https://images.unsplash.com/photo-1570035598720-bdddb30100dd'),
(22, '9876543210983', 'Professional Shedder', 'Fluffy the Furball, shedding expert! He''ll leave a trail of fur wherever he goes.', 3, 'CZK', 60.00, 'Shed', 'https://images.unsplash.com/photo-1577137726038-f307f80d7f0a'),
(23, '5678901234562', 'Canine Choreographer', 'Twirls the Terrier, dance instructor extraordinaire! He''ll teach you the latest dog dancing moves.', 8, 'CZK', 190.00, 'Dance', 'https://images.unsplash.com/photo-1590449775129-794a1')
;