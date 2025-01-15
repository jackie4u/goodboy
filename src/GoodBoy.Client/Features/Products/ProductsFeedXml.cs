namespace GoodBoy.Client.Features.Products;

public static class ProductsFeedXml
{
    public static string LoadXmlContent()
    {
        return @"
            <?xml version='1.0' encoding='utf-8'?>
            <products>
              <product>
                <id>1</id>
                <ean>1234567890123</ean>
                <name>Pillow Shredder</name>
                <description>Meet Chompy, the ultimate pillow destroyer! He's got sharp teeth and a passion for fluff.</description>
                <quantity>5</quantity>
                <price>150.00</price>
                <currency>CZK</currency>
                <categories>Destroy</categories>
                <mainPicture>https://images.unsplash.com/photo-1517849845537-4d257902454a</mainPicture> 
              </product>
              <product>
                <id>2</id>
                <ean>9876543210987</ean>
                <name>Professional Cuddler</name>
                <description>Rent Snuggles, the cuddle champion! He's a fluffy cloud of warmth and affection.</description>
                <quantity>3</quantity>
                <price>200.00</price>
                <currency>CZK</currency>
                <categories>Cuddle</categories>
                <mainPicture>https://images.unsplash.com/photo-1548199973-03cce0bbc87b</mainPicture>
              </product>
              <product>
                <id>3</id>
                <ean>5678901234567</ean>
                <name>Barking Mad</name>
                <description>Introducing Howler, the acoustic tester! He'll bark at anything and everything.</description>
                <quantity>7</quantity>
                <price>100.00</price>
                <currency>CZK</currency>
                <categories>Bark</categories>
                <mainPicture>https://images.unsplash.com/photo-1567529684892-09290a1b2d05</mainPicture>
              </product>
              <product>
                <id>1001</id>
                <ean>4321098765432</ean>
                <name>Canine Therapist</name>
                <description>Dr. Woof is here for your emotional support! He's a good listener and a great hugger.</description>
                <quantity>2</quantity>
                <price>300.00</price>
                <currency>CZK</currency>
                <categories>Therapy</categories>
                <mainPicture>https://images.unsplash.com/photo-1591856391054-7ffd7a2c44ef</mainPicture>
              </product>
              <product>
                <id>5</id>
                <ean>8901234567890</ean>
                <name>Scratching Post Pro</name>
                <description>Scratchy McScratchface, the itch reliever! He'll scratch anything you need scratched.</description>
                <quantity>4</quantity>
                <price>120.00</price>
                <currency>CZK</currency>
                <categories>Scratch</categories>
                <mainPicture>https://images.unsplash.com/photo-1518717758536-85ae29035b6d</mainPicture>
              </product>
              <product>
                <id>6</id>
                <ean>3210987654321</ean>
                <name>Agility Ace</name>
                <description>Zoom, the speed demon, for your sporting needs! He's fast, agile, and loves to run.</description>
                <quantity>6</quantity>
                <price>250.00</price>
                <currency>CZK</currency>
                <categories>Sport</categories>
                <mainPicture>https://images.unsplash.com/photo-1477868433719-7c5f2731b310</mainPicture>
              </product>
              <product>
                <id>7</id>
                <ean>7890123456789</ean>
                <name>Muddy Paws</name>
                <description>Get dirty with Mudslide, the mud enthusiast! He'll roll in anything you point him at.</description>
                <quantity>8</quantity>
                <price>80.00</price>
                <currency>CZK</currency>
                <categories>Mud</categories>
                <mainPicture>https://images.unsplash.com/photo-1516371535707-512a1e83bb9a</mainPicture>
              </product>
              <product>
                <id>8</id>
                <ean>2109876543210</ean>
                <name>Drool Monster</name>
                <description>Slobbers McGee, the drool expert! He'll leave a trail of slobber wherever he goes.</description>
                <quantity>3</quantity>
                <price>50.00</price>
                <currency>CZK</currency>
                <categories>Drool</categories>
                <mainPicture>https://images.unsplash.com/photo-1561037404-61cd46aa615b</mainPicture>
              </product>
              <product>
                <id>9</id>
                <ean>6543210987654</ean>
                <name>Professional Sniffer</name>
                <description>Sherlock Bones, the nose with the knows! He can sniff out anything you need.</description>
                <quantity>1</quantity>
                <price>500.00</price>
                <currency>CZK</currency>
                <categories>Sniff</categories>
                <mainPicture>https://images.unsplash.com/photo-1503256207526-0d5d80fa2f47</mainPicture>
              </product>
              <product>
                <id>10</id>
                <ean>0987654321098</ean>
                <name>Hairy Houdini</name>
                <description>Escape artist extraordinaire, Houdini the Hound! He can escape from any enclosure.</description>
                <quantity>2</quantity>
                <price>400.00</price>
                <currency>CZK</currency>
                <categories>Escape</categories>
                <mainPicture>https://images.unsplash.com/photo-1450778869180-41d0601e046e</mainPicture>
              </product>
              <product>
                <id>11</id>
                <ean>9876543210123</ean>
                <name>Barking Maestro</name>
                <description>Beethoven the Beagle, for your musical needs! He'll howl along to any tune.</description>
                <quantity>5</quantity>
                <price>180.00</price>
                <currency>CZK</currency>
                <categories>Music</categories>
                <mainPicture>https://images.unsplash.com/photo-1532592333381-a141e3f197c9</mainPicture>
              </product>
              <product>
                <id>12</id>
                <ean>8765432109876</ean>
                <name>Professional Digger</name>
                <description>Holes McGee, the excavation expert! He'll dig you a hole to China if you let him.</description>
                <quantity>4</quantity>
                <price>130.00</price>
                <currency>CZK</currency>
                <categories>Dig</categories>
                <mainPicture>https://images.unsplash.com/photo-1453227588063-bb302b62f50b</mainPicture>
              </product>
              <product>
                <id>13</id>
                <ean>7654321098765</ean>
                <name>Canine Comedian</name>
                <description>Chuckles the Clown, guaranteed to make you laugh! He's got more jokes than fleas.</description>
                <quantity>6</quantity>
                <price>220.00</price>
                <currency>CZK</currency>
                <categories>Comedy</categories>
                <mainPicture>https://images.unsplash.com/photo-1505628346881-b72b27e84530</mainPicture>
              </product>
              <product>
                <id>14</id>
                <ean>6543210987654</ean>
                <name>Frisbee Fanatic</name>
                <description>Catcher the Collie, frisbee champion! He'll catch anything you throw, even your bad moods.</description>
                <quantity>7</quantity>
                <price>110.00</price>
                <currency>CZK</currency>
                <categories>Frisbee</categories>
                <mainPicture>https://images.unsplash.com/photo-1497993950456-cdb57afd1cf1</mainPicture>
              </product>
              <product>
                <id>15</id>
                <ean>5432109876543</ean>
                <name>Professional Napper</name>
                <description>Sleepy the Sloth, master of relaxation! He'll teach you the art of the perfect nap.</description>
                <quantity>3</quantity>
                <price>70.00</price>
                <currency>CZK</currency>
                <categories>Nap</categories>
                <mainPicture>https://images.unsplash.com/photo-1542115543-635dd3de8106</mainPicture>
              </product>
              <product>
                <id>16</id>
                <ean>4321098765432</ean>
                <name>Treat Tester</name>
                <description>Taster the Terrier, connoisseur of treats! He'll give you his expert opinion on any snack.</description>
                <quantity>8</quantity>
                <price>90.00</price>
                <currency>CZK</currency>
                <categories>Treat</categories>
                <mainPicture>https://images.unsplash.com/photo-1520824646108-ead469543c94</mainPicture>
              </product>
            </products>
            ";
    }
}