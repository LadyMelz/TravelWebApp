using TravelWebAPI.Models;

namespace TravelWebAPI.Data
{
    public class AppDbIntializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDataContext>();

                if (!context.Attractions.Any())
                {
                    context.Attractions.AddRange(new Attraction()
                    {
                        Title = "National Museum of Ethiopia",
                        Short_Description = "The National Museum of Ethiopia (NME), also referred to as the Ethiopian National Museum, is a national museum in Ethiopia." +
                        " It is located in the capital, Addis Ababa, near the Addis Ababa University's graduate school.",
                        Long_Description = "The museum houses Ethiopia's artistic treasures. " +
                        "It contains many precious local archaeological finds such as the fossilized remains of early hominids, " +
                        "the most famous of which is \"Lucy,\" the partial skeleton of a specimen of Australopithecus afarensis. " +
                        "Recently added to the basement gallery is a display on Selam, found between 2000 and 2004. " +
                        "This archaic fossil is estimated to date to 3.3 million years ago.\r\n\r\nIn 1936, " +
                        "the concept of a museum was first introduced in Ethiopia when an exhibition was opened, " +
                        "displaying ceremonial costumes donated by the Solomonic dynasty and their close associates. " +
                        "The current NME grew from the establishment of the Institute of Archaeology, which was founded in 1958. " +
                        "The institute was founded to promote and facilitate the archaeological research mission in the northern part of Ethiopia by French archaeologists.",
                        ImgURL = "national museum of ethiopia.png",
                        Link = "https://en.wikipedia.org/wiki/National_Museum_of_Ethiopia",
                        Location = "Addis Ababa, Ethiopia"
                    },
                    new Attraction()
                    {
                        Title = "Rock-Hewn Churches, Lalibela",
                        Short_Description = "The eleven Rock-hewn Churches of Lalibela are monolithic churches located in the Western Ethiopian Highlands near the town of Lalibela," +
                        " named after the late-12th and early-13th century King Gebre Meskel Lalibela of the Zagwe dynasty, " +
                        "who commissioned the massive building project of 11 rock-hewn churches to recreate the holy city of Jerusalem in his own kingdom. " +
                        "The site remains in use by the Ethiopian Orthodox Christian Church to this day, " +
                        "and it remains an important place of pilgrimage for Ethiopian Orthodox worshipers.[1] It took 24 years to build all the 11 rock hewn churches.",
                        Long_Description = "According to local tradition, " +
                        "Lalibela (traditionally known as Roha) was founded by an Agew family called the Zagwa or Zagwe in 1137 AD." +
                        " The churches are said to have been built during the Zagwe dynasty, under the rule of King Gebre Mesqel Lalibela," +
                        " although it is more likely that they evolved into their current form over the course of several phases of construction " +
                        "and alteration of preexisting structures.",
                        ImgURL = "lalibela-downwards.png",
                        Link = "https://en.wikipedia.org/wiki/Rock-Hewn_Churches,_Lalibela",
                        Location = "Lalibele, Amhara, Ethiopia"
                    },
                    new Attraction()
                    {
                        Title = "Simien Mountains National Park",
                        Short_Description = "Simien Mountains National Park is the largest national park in Ethiopia." +
                        " Located in the North Gondar Zone of the Amhara Region, its territory covers the highest parts of the Simien Mountains and includes Ras Dashan," +
                        " the highest point in Ethiopia.",
                        Long_Description = "It is home to a number of endangered species, " +
                        "including the Ethiopian wolf and the walia ibex, a wild goat found nowhere else in the world. " +
                        "The gelada baboon and the caracal, a cat, also occur within the Simien Mountains. More than 50 species of birds inhabit the park, " +
                        "including the bearded vulture, or lammergeier, with its 3-metre (10 ft) wingspan." +
                        "\r\n\r\nThe park is crossed by an unpaved road which runs from Debarq, where the administrative headquarters of the park is located," +
                        " east through a number of villages to the 4,430 metres (14,530 ft) Buahit Pass, where the road turns south to end at Mekane Berhan," +
                        " 10 kilometres (6 mi) beyond the park boundary.",
                        ImgURL = "simien mtn.png",
                        Link = "https://en.wikipedia.org/wiki/Simien_Mountains_National_Park",
                        Location = "Gondar, Amhara, Ethiopia"
                    },
                    new Attraction()
                    {
                        Title = "Gondar",
                        Short_Description = "Gondar previously served as the capital of both the Ethiopian Empire and the subsequent Begemder Province. " +
                        "The city holds the remains of several royal castles, including those in the Fasil Ghebbi UNESCO World Heritage Site for which Gondar " +
                        "has been called the \"Camelot of Africa\".",
                        Long_Description = "Until the 16th century, the Solomonic Emperors of Ethiopia usually had no fixed capital town," +
                        " but instead lived in tents in temporary royal camps as they moved around their realms while their family," +
                        " bodyguard and retinue devoured surplus crops and cut down nearby trees for firewood. One exception to this rule was Debre Berhan," +
                        " founded by Zara Yaqob in 1456; Tegulet in Shewa was also essentially the capital during the first century of Solomonic rule." +
                        " Gondar was founded by Emperor Fasilides around the year 1635, and grew as an agricultural and market town." +
                        " There was a superstition at the time that the capital's name should begin with the letter 'Gʷa' (modern pronunciation 'Gʷe'; " +
                        "Gonder was originally spelt Gʷandar), which also contributed to Gorgora's (founded as Gʷargʷara) growth in the centuries after 1600. " +
                        "Tradition also states that a buffalo led the Emperor Fasilides to a pool beside the Angereb, " +
                        "where an \"old and venerable hermit\" told the Emperor he would locate his capital there. " +
                        "Fasilides had the pool filled in and built his castle on that same site.[4] The emperor also built a total of seven churches;" +
                        " the first two, Fit Mikael and Qedus Abbo, were built to end local epidemics." +
                        " The five emperors who followed him also built their palaces in the town.",
                        ImgURL = "gondar-afar.png",
                        Link = "https://en.wikipedia.org/wiki/Gondar",
                        Location = "Gondar, Amhara, Ethiopia"
                    });
                }

                if (!context.Events.Any())
                {
                    context.Events.AddRange(new Event()
                    {
                        Title = "Adwa Del Beal",
                        Short_Description = "The celebration of victory on The Battle of Adwa.",
                        Long_Description = "The Battle of Adwa (Amharic: የዐድዋ ጦርነት; Tigrinya: ውግእ ዓድዋ; Italian: battaglia di Adua, also spelled Adowa) was the climactic battle of the First Italo-Ethiopian War." +
                           " The Ethiopian forces defeated the Italian invading force on Sunday 1 March 1896, near the town of Adwa." +
                           " The decisive victory thwarted the campaign of the Kingdom of Italy to expand its colonial empire in the Horn of Africa.[3] By the end of the 19th century," +
                           " European powers had carved up almost all of Africa after the Berlin Conference; only Ethiopia and Liberia still maintained their independence." +
                           " Adwa became a pre-eminent symbol of pan-Africanism and secured Ethiopian sovereignty until the Second Italo-Ethiopian War forty years later.",
                        ImgURL = "adwa.png",
                        Link = "https://en.wikipedia.org/wiki/Battle_of_Adwa",
                        Location = "Adwa, Tigray, Ethiopia",
                        Date = DateTime.Now
                    },
                    new Event()
                    {
                        Title = "The Great Ethiopian Run",
                        Short_Description = "The Great Ethiopian Run (Amharic: ታላቁ ሩጫ በኢትዮጵያ)" +
                           " is an annual 10-kilometre road running event which takes place in late November in Addis Ababa, Ethiopia.",
                        Long_Description = "The competition was first envisioned by neighbors Ethiopian runner Haile Gebrselassie, Peter Middlebrook and Abi Masefield in late October 2000, " +
                           "following Haile's return from the 2000 Summer Olympics." +
                           " The 10,000 entries for the first edition quickly sold out and other people unofficially joined the race without a number." +
                           " The creation of the race marked the first time that a major annual 10  km race had been held in the country, renowned for producing world-class runners." +
                           " The day's events include an international and popular 10 km race and a 5 km women-only race.",
                        ImgURL = "greatEthiopianRun.png",
                        Link = "https://en.wikipedia.org/wiki/Great_Ethiopian_Run",
                        Location = "Addis Ababa, Ethiopia",
                        Date = DateTime.Now
                    },
                    new Event()
                    {
                        Title = "Enkutatash",
                        Short_Description = "Enkutatash (Ge'ez: እንቁጣጣሽ) is a public holiday in coincidence of New Year in Ethiopia and Eritrea." +
                           " It occurs on Meskerem 1 on the Ethiopian calendar, which is 11 September (or, during a leap year, 12 September) according to the Gregorian calendar.",
                        Long_Description = "According to Ethiopian tradition," +
                           " on 11 September Queen of Sheba (Makeda in Ethiopian) returned to Ethiopia from her visit to King Solomon in Jerusalem." +
                           " Her followers celebrated her return by giving her jewels." +
                           " Hence ‘‘Enkutatash’’ means the ‘‘gift of jewels’’. This holiday is based on the Ethiopian calendar. It is the Ethiopian New Year." +
                           "\r\n\r\nLarge celebrations are held around the country, notably at the Raguel Church on Mount Entoto.",
                        ImgURL = "adey abeba.png",
                        Link = "https://en.wikipedia.org/wiki/Enkutatash",
                        Location = "Ethiopia",
                        Date = DateTime.Now
                    },
                    new Event()
                    {
                        Title = "Timket Beal (Epiphany)",
                        Short_Description = "Timket (Ge'ez: ጥምቀት T’imk’et) is an Ethiopian Orthodox Tewahedo Church and Eritrean Orthodox Tewahedo Church celebration of Epiphany." +
                           " It is celebrated on 19 January (or 20 in a leap year), corresponding to the 11th day of Terr in the Ge'ez calendar.",
                        Long_Description = "Timket celebrates the baptism of Jesus in the River Jordan. " +
                           "This festival is best known for its ritual reenactment of baptism (similar to such reenactments performed by numerous Christian the Holy Land when they visit the Jordan)." +
                           "\r\n\r\n\r\nEthiopian Tewahedo priests at a Timket ceremony in Jan Meda." +
                           "\r\nDuring the ceremonies of Timket, the Tabot, a model of the Ark of the Covenant, " +
                           "which is present on every Ethiopian altar (somewhat like the Western altar stone), " +
                           "is reverently wrapped in rich cloth and borne in procession on the head of the priest." +
                           " The Tabot, which is otherwise rarely seen by the laity, represents the manifestation of Jesus as the Messiah when he came to the Jordan for baptism." +
                           " The Divine Liturgy is celebrated near a stream or pool early in the morning (around 2 a.m.). " +
                           "Then the nearby body of water is blessed towards dawn and sprinkled on the participants, some of whom enter the water and immerse themselves, " +
                           "symbolically renewing their baptismal vows. ",
                        ImgURL = "timket.png",
                        Link = "https://en.wikipedia.org/wiki/Timkat",
                        Location = "Gondar, Amhara, Ethiopia",
                        Date = DateTime.Now
                    });
                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User()
                        {
                            FullName = "Melat Gizachew",
                            Email = "meziworku@gmail.com",
                            Password = "Random5678",
                            Phone = "0929495169",
                            ImgURL = "me.jpg"
                        },

                        new User()
                        {
                            FullName = "Admin",
                            Email = "admin@travel.et",
                            Password = "12345",
                            Phone = "0912345678",
                            ImgURL = "default-profile.png"
                        },

                        new User()
                        {
                            FullName = "Bezawit Gizachew",
                            Email = "beza.g.worku@gmail.com",
                            Password = "password",
                            Phone = "0929093798",
                            ImgURL = "beza.jpeg"
                        },

                        new User()
                        {
                            FullName = "Kidist Tadele",
                            Email = "kidist.t.gebrehiwot@gmail.com",
                            Password = "IluvMelat",
                            Phone = "0962492680",
                            ImgURL = "her.jpg"
                        });
                    context.SaveChanges();
                }

                if (!context.Itineraries.Any())
                {
                    context.Itineraries.AddRange(
                        new Itinerary()
                        {
                            Name = "Trip to the North",
                            img = "icon.png",
                            Start = DateTime.Now,
                            End = DateTime.Now,
                            Transportation = "Airplane",
                            Location = "Amhara, Ethiopia",
                            UserId = 2

                        });
                    context.SaveChanges();
                }

                //if (!context.Attraction_Itineraries.Any())
                //{
                //    context.Attraction_Itineraries.AddRange(
                //        new Attraction_Itinerary()
                //        {
                //           AttractionId = 2,
                //           ItineraryId = 1

                //        },


                //        new Attraction_Itinerary()
                //        {
                //            AttractionId = 3,
                //            ItineraryId = 1

                //        },


                //        new Attraction_Itinerary()
                //        {
                //            AttractionId = 4,
                //            ItineraryId = 1

                //        });
                //    context.SaveChanges();
                //}

                //if (!context.Event_Itineraries.Any())
                //{
                //    context.Event_Itineraries.AddRange(
                //        new Event_Itinerary()
                //        {
                //            EventId = 4,
                //            ItineraryId = 1

                //        });
                //    context.SaveChanges();
                //}
            }
        }
    }
}
