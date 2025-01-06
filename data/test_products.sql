USE [goodboydb]
GO

SELECT *
  FROM dbo.Products AS P
;

/*
  TRUNCATE TABLE dbo.Products
*/


INSERT INTO [dbo].[Products] ([Id], [Ean], [Name], [Description], [Quantity], [Currency], [Price], [Categories], [MainPicture], [CreatedOn], [UpdatedOn]) VALUES
(1, '1234567890123', 'Pillow Shredder', 'Meet Chompy, the ultimate pillow destroyer! He''s got sharp teeth and a passion for fluff.', 5, 'CZK', 150.00, 'Destroy', 'https://images.unsplash.com/photo-1517849845537-4d257902454a', '2024-03-15 10:22:33', '2024-03-15 11:22:33'),
(2, '9876543210987', 'Professional Cuddler', 'Rent Snuggles, the cuddle champion! He''s a fluffy cloud of warmth and affection.', 3, 'CZK', 200.00, 'Cuddle', 'https://images.unsplash.com/photo-1548199973-03cce0bbc87b', '2024-06-20 14:35:12', '2024-06-20 16:35:12'),
(3, '5678901234567', 'Barking Mad', 'Introducing Howler, the acoustic tester! He''ll bark at anything and everything.', 7, 'CZK', 100.00, 'Bark', 'https://images.unsplash.com/photo-1567529684892-09290a1b2d05', '2024-09-05 08:15:45', '2024-09-05 09:15:45'),
(4, '4321098765432', 'Canine Therapist', 'Dr. Woof is here for your emotional support! He''s a good listener and a great hugger.', 2, 'CZK', 300.00, 'Therapy', 'https://images.unsplash.com/photo-1591856391054-7ffd7a2c44ef', '2024-11-12 16:58:21', '2024-11-12 18:58:21'),
(5, '8901234567890', 'Scratching Post Pro', 'Scratchy McScratchface, the itch reliever! He''ll scratch anything you need scratched.', 4, 'CZK', 120.00, 'Scratch', 'https://images.unsplash.com/photo-1518717758536-85ae29035b6d', '2024-02-28 11:30:54', '2024-03-01 11:30:54'),
(6, '3210987654321', 'Agility Ace', 'Zoom, the speed demon, for your sporting needs! He''s fast, agile, and loves to run.', 6, 'CZK', 250.00, 'Sport', 'https://images.unsplash.com/photo-1477868433719-7c5f2731b310', '2024-07-18 20:12:09', '2024-07-19 08:12:09'),
(7, '7890123456789', 'Muddy Paws', 'Get dirty with Mudslide, the mud enthusiast! He''ll roll in anything you point him at.', 8, 'CZK', 80.00, 'Mud', 'https://images.unsplash.com/photo-1516371535707-512a1e83bb9a', '2024-10-01 09:45:33', '2024-10-02 09:45:33'),
(8, '2109876543210', 'Drool Monster', 'Slobbers McGee, the drool expert! He''ll leave a trail of slobber wherever he goes.', 3, 'CZK', 50.00, 'Drool', 'https://images.unsplash.com/photo-1561037404-61cd46aa615b', '2024-01-15 15:22:18', '2024-01-16 15:22:18'),
(9, '6543210987654', 'Professional Sniffer', 'Sherlock Bones, the nose with the knows! He can sniff out anything you need.', 1, 'CZK', 500.00, 'Sniff', 'https://images.unsplash.com/photo-1503256207526-0d5d80fa2f47', '2024-05-10 12:05:59', '2024-05-11 12:05:59'),
(10, '0987654321098', 'Hairy Houdini', 'Escape artist extraordinaire, Houdini the Hound! He can escape from any enclosure.', 2, 'CZK', 400.00, 'Escape', 'https://images.unsplash.com/photo-1450778869180-41d0601e046e', '2024-08-22 21:38:42', '2024-08-23 10:38:42'),
(11, '9876543210123', 'Barking Maestro', 'Beethoven the Beagle, for your musical needs! He''ll howl along to any tune.', 5, 'CZK', 180.00, 'Music', 'https://images.unsplash.com/photo-1532592333381-a141e3f197c9', '2024-12-03 17:11:25', '2024-12-04 10:11:25'),
(12, '8765432109876', 'Professional Digger', 'Holes McGee, the excavation expert! He''ll dig you a hole to China if you let him.', 4, 'CZK', 130.00, 'Dig', 'https://images.unsplash.com/photo-1453227588063-bb302b62f50b', '2024-04-18 09:54:17', '2024-04-19 10:54:17'),
(13, '7654321098765', 'Canine Comedian', 'Chuckles the Clown, guaranteed to make you laugh! He''s got more jokes than fleas.', 6, 'CZK', 220.00, 'Comedy', 'https://images.unsplash.com/photo-1505628346881-b72b27e84530', '2024-07-25 14:28:39', '2024-07-26 11:28:39'),
(14, '6543210987654', 'Frisbee Fanatic', 'Catcher the Collie, frisbee champion! He''ll catch anything you throw, even your bad moods.', 7, 'CZK', 110.00, 'Frisbee', 'https://images.unsplash.com/photo-1497993950456-cdb57afd1cf1', '2024-10-11 22:15:03', '2024-10-12 14:15:03'),
(15, '5432109876543', 'Professional Napper', 'Sleepy the Sloth, master of relaxation! He''ll teach you the art of the perfect nap.', 3, 'CZK', 70.00, 'Nap', 'https://images.unsplash.com/photo-1542115543-635dd3de8106', '2024-03-08 18:42:51', '2024-03-09 10:42:51'),
(16, '4321098765432', 'Treat Tester', 'Taster the Terrier, connoisseur of treats! He''ll give you his expert opinion on any snack.', 8, 'CZK', 90.00, 'Treat', 'https://images.unsplash.com/photo-1520824646108-ead469543c94', '2024-06-15 13:18:27', '2024-06-16 09:18:27');