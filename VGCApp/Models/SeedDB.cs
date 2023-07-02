using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VGCApp.Data;
using System;
using System.Linq;

namespace VGCApp.Models
{
    public static class SeedDB
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new VGCAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<VGCAppContext>>()))
            {
                // Look for any movies.
                if (context.VideoGameModel.Any())
                {
                    return;   // DB has been seeded
                }

                context.VideoGameModel.AddRange(
                    new VideoGameModel
                    {
                        Title = "Destiny 2",
                        Description = @"Destiny 2 is a free-to-play online first-person shooter video game developed by Bungie. It was originally released as a pay to play game in 2017 for PlayStation 4, Xbox One, and Windows.",
                        ReleaseDate = DateTime.Parse("2017-9-6"),
                        Genre = "First Person Shooter",
                        Price = 0.00M
                    },
                    new VideoGameModel
                    {
                        Title = "Call of Duty: Modern Warfare II",
                        Description = @"Call of Duty: Modern Warfare II is a 2022 first-person shooter video game developed by Infinity Ward and published by Activision. It is a sequel to the 2019 reboot, and serves as the nineteenth installment in the overall Call of Duty series.",
                        ReleaseDate = DateTime.Parse("2022-9-17"),
                        Genre = "First Person Shooter",
                        Price = 39.99M
                    },
                    new VideoGameModel
                    {
                        Title = "Diablo IV",
                        Description = @"Diablo IV is a 2023 multiplayer-only action role-playing game developed and published by Blizzard Entertainment. It is the fourth main installment in the Diablo series.",
                        ReleaseDate = DateTime.Parse("2023-5-9"),
                        Genre = "Hack and Slash",
                        Price = 69.99M
                    },
                    new VideoGameModel
                    {
                        Title = "Minecraft",
                        Description = @"Minecraft is a 2011 sandbox game developed by Mojang Studios. In Minecraft, players explore a blocky, procedurally generated, three-dimensional world with virtually infinite terrain and may discover and extract raw materials, craft tools and items, and build structures, earthworks, and machines.",
                        ReleaseDate = DateTime.Parse("2011-11-18"),
                        Genre = "Sandbox",
                        Price = 29.99M
                    },
                    new VideoGameModel
                    {
                        Title = "God of War Ragnarök",
                        Description = @"God of War Ragnarök is an action-adventure game developed by Santa Monica Studio and published by Sony Interactive Entertainment. It was released worldwide on November 9, 2022, for both the PlayStation 4 and PlayStation 5, marking the first cross-gen release in the God of War series.",
                        ReleaseDate = DateTime.Parse("2022-11-9"),
                        Genre = "Hack and Slash",
                        Price = 59.99M
                    }
                    ,
                    new VideoGameModel
                    {
                        Title = "Metal Gear Rising: Revengeance",
                        Description = @"Metal Gear Rising: Revengeance is a 2013 action-adventure game developed by PlatinumGames and published by Konami. It was released for the PlayStation 3 and Xbox 360 in February 2013, Windows and OS X in January and September 2014, and Nvidia Shield TV in January 2016.",
                        ReleaseDate = DateTime.Parse("2013-2-19"),
                        Genre = "Stealth game",
                        Price = 29.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

