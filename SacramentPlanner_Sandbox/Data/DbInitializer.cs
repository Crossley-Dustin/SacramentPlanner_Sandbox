﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SacramentPlanner_Sandbox.Models;

namespace SacramentPlanner_Sandbox.Data
{
    public class DbInitializer
    {
        public static void Initialize(MeetingContext context)
        {
            context.Database.EnsureCreated();

            // Check for any Person table entries
            if (context.Person.Any())
            {
                return; // DB already seeded
            }

            var people = new Person[]
            {
                new Person{FirstName="Carson",MiddleInitial="A",LastName="Alexander",Discriminator="Bishopric"}
                , new Person{FirstName="Benjamin",MiddleInitial="B",LastName="Anderson",Discriminator="Bishopric"}
                , new Person{FirstName="Hank",MiddleInitial="C",LastName="Smith",Discriminator="Bishopric"}
                , new Person{FirstName="Caroline",MiddleInitial="D",LastName="Azevedo",Discriminator="Member"}
                , new Person{FirstName="Greg",MiddleInitial="E",LastName="Peterson",Discriminator="Member"}
                , new Person{FirstName="Nancy",MiddleInitial="F",LastName="Alonso",Discriminator="Member"}
                , new Person{FirstName="Elizabeth",MiddleInitial="G",LastName="Perez",Discriminator="Member"}
                , new Person{FirstName="Norman",MiddleInitial="H",LastName="Olivetti",Discriminator="Member"}
                , new Person{FirstName="Laura",MiddleInitial="I",LastName="Abercrombie",Discriminator="Member"}
                , new Person{FirstName="Peggy",MiddleInitial="J",LastName="Berrett",Discriminator="Member"}
            };

            foreach (Person p in people)
            {
                context.Person.Add(p);
            }
            context.SaveChanges();

            // Check for any Hymn table entries
            if (context.Hymn.Any())
            {
                return; // DB already seeded
            }

            Hymn[] hymns = GetHymnList();

            foreach (Hymn h in hymns)
            {
                context.Hymn.Add(h);
            }
            context.SaveChanges();

            // Check for any Meeting table entries
            if (context.Meeting.Any())
            {
                return; // DB already seeded
            }

            var meetings = new Meeting[]
            {
                new Meeting {
                    MeetingDate = DateTime.Parse("12/17/2017")
                    ,Conducting = people.Single( p => p.FirstName == "Carson" && p.LastName == "Alexander" ).PersonID
                    ,OpeningHymn = hymns.Single( h => h.HymnNumber == 6 ).HymnID
                    ,OpeningPrayer = people.Single ( p => p.LastName == "Perez" ).PersonID
                    ,SacramentHymn = hymns.Single( h => h.HymnNumber == 252 ).HymnID
                    ,IntermediateSong = "252 Onward Christian Soldiers"
                    ,ClosingHymn = hymns.Single( h => h.HymnNumber == 19 ).HymnID
                    ,ClosingPrayer = people.Single( p => p.LastName == "Olivetti" ).PersonID
                } 
            };

            foreach (Meeting m in meetings)
            {
                context.Meeting.Add(m);
            }
            context.SaveChanges();
        }

        private static Hymn[] GetHymnList()
        {
            Hymn[] list = new Hymn[]
            {
                new Hymn{HymnNumber=1,HymnName="The Morning Breaks"}
                , new Hymn{HymnNumber=2,HymnName="The Spirit of God"}
                , new Hymn{HymnNumber=3,HymnName="Now Let Us Rejoice"}
                , new Hymn{HymnNumber=4,HymnName="Truth Eternal"}
                , new Hymn{HymnNumber=5,HymnName="High on the Mountain Top"}
                , new Hymn{HymnNumber=6,HymnName="Redeemer of Israel"}
                , new Hymn{HymnNumber=7,HymnName="Israel, Israel, God Is Calling"}
                , new Hymn{HymnNumber=8,HymnName="Awake and Arise"}
                , new Hymn{HymnNumber=9,HymnName="Come, Rejoice"}
                , new Hymn{HymnNumber=10,HymnName="Come, Sing to the Lord"}
                , new Hymn{HymnNumber=11,HymnName="What Was Witnessed in the Heavens?"}
                , new Hymn{HymnNumber=12,HymnName="’Twas Witnessed in the Morning Sky*"}
                , new Hymn{HymnNumber=13,HymnName="An Angel from on High"}
                , new Hymn{HymnNumber=14,HymnName="Sweet Is the Peace the Gospel Brings"}
                , new Hymn{HymnNumber=15,HymnName="I Saw a Mighty Angel Fly"}
                , new Hymn{HymnNumber=16,HymnName="What Glorious Scenes Mine Eyes Behold"}
                , new Hymn{HymnNumber=17,HymnName="Awake, Ye Saints of God, Awake!"}
                , new Hymn{HymnNumber=18,HymnName="The Voice of God Again Is Heard"}
                , new Hymn{HymnNumber=19,HymnName="We Thank Thee, O God, for a Prophet"}
                , new Hymn{HymnNumber=20,HymnName="God of Power, God of Right"}
                , new Hymn{HymnNumber=21,HymnName="Come, Listen to a Prophet’s Voice"}
                , new Hymn{HymnNumber=22,HymnName="We Listen to a Prophet’s Voice"}
                , new Hymn{HymnNumber=23,HymnName="We Ever Pray for Thee"}
                , new Hymn{HymnNumber=24,HymnName="God Bless Our Prophet Dear"}
                , new Hymn{HymnNumber=25,HymnName="Now We’ll Sing with One Accord"}
                , new Hymn{HymnNumber=26,HymnName="Joseph Smith’s First Prayer"}
                , new Hymn{HymnNumber=27,HymnName="Praise to the Man"}
                , new Hymn{HymnNumber=28,HymnName="Saints, Behold How Great Jehovah"}
                , new Hymn{HymnNumber=29,HymnName="A Poor Wayfaring Man of Grief"}
                , new Hymn{HymnNumber=30,HymnName="Come, Come, Ye Saints"}
                , new Hymn{HymnNumber=31,HymnName="O God, Our Help in Ages Past"}
                , new Hymn{HymnNumber=32,HymnName="The Happy Day at Last Has Come"}
                , new Hymn{HymnNumber=33,HymnName="Our Mountain Home So Dear"}
                , new Hymn{HymnNumber=34,HymnName="O Ye Mountains High"}
                , new Hymn{HymnNumber=35,HymnName="For the Strength of the Hills"}
                , new Hymn{HymnNumber=36,HymnName="They, the Builders of the Nation"}
                , new Hymn{HymnNumber=37,HymnName="The Wintry Day, Descending to Its Close"}
                , new Hymn{HymnNumber=38,HymnName="Come, All Ye Saints of Zion"}
                , new Hymn{HymnNumber=39,HymnName="O Saints of Zion"}
                , new Hymn{HymnNumber=40,HymnName="Arise, O Glorious Zion"}
                , new Hymn{HymnNumber=41,HymnName="Let Zion in Her Beauty Rise"}
                , new Hymn{HymnNumber=42,HymnName="Hail to the Brightness of Zion’s Glad Morning!"}
                , new Hymn{HymnNumber=43,HymnName="Zion Stands with Hills Surrounded"}
                , new Hymn{HymnNumber=44,HymnName="Beautiful Zion, Built Above"}
                , new Hymn{HymnNumber=45,HymnName="Lead Me into Life Eternal"}
                , new Hymn{HymnNumber=46,HymnName="Glorious Things of Thee Are Spoken"}
                , new Hymn{HymnNumber=47,HymnName="We Will Sing of Zion"}
                , new Hymn{HymnNumber=48,HymnName="Glorious Things Are Sung of Zion"}
                , new Hymn{HymnNumber=49,HymnName="Adam-ondi-Ahman"}
                , new Hymn{HymnNumber=50,HymnName="Come, Thou Glorious Day of Promise"}
                , new Hymn{HymnNumber=51,HymnName="Sons of Michael, He Approaches"}
                , new Hymn{HymnNumber=52,HymnName="The Day Dawn Is Breaking"}
                , new Hymn{HymnNumber=53,HymnName="Let Earth’s Inhabitants Rejoice"}
                , new Hymn{HymnNumber=54,HymnName="Behold, the Mountain of the Lord*"}
                , new Hymn{HymnNumber=55,HymnName="Lo, the Mighty God Appearing!"}
                , new Hymn{HymnNumber=56,HymnName="Softly Beams the Sacred Dawning"}
                , new Hymn{HymnNumber=57,HymnName="We’re Not Ashamed to Own Our Lord"}
                , new Hymn{HymnNumber=58,HymnName="Come, Ye Children of the Lord"}
                , new Hymn{HymnNumber=59,HymnName="Come, O Thou King of Kings"}
                , new Hymn{HymnNumber=60,HymnName="Battle Hymn of the Republic"}
                , new Hymn{HymnNumber=61,HymnName="Raise Your Voices to the Lord"}
                , new Hymn{HymnNumber=62,HymnName="All Creatures of Our God and King"}
                , new Hymn{HymnNumber=63,HymnName="Great King of Heaven"}
                , new Hymn{HymnNumber=64,HymnName="On This Day of Joy and Gladness"}
                , new Hymn{HymnNumber=65,HymnName="Come, All Ye Saints Who Dwell on Earth"}
                , new Hymn{HymnNumber=66,HymnName="Rejoice, the Lord Is King!"}
                , new Hymn{HymnNumber=67,HymnName="Glory to God on High"}
                , new Hymn{HymnNumber=68,HymnName="A Mighty Fortress Is Our God"}
                , new Hymn{HymnNumber=69,HymnName="All Glory, Laud, and Honor"}
                , new Hymn{HymnNumber=70,HymnName="Sing Praise to Him"}
                , new Hymn{HymnNumber=71,HymnName="With Songs of Praise"}
                , new Hymn{HymnNumber=72,HymnName="Praise to the Lord, the Almighty"}
                , new Hymn{HymnNumber=73,HymnName="Praise the Lord with Heart and Voice"}
                , new Hymn{HymnNumber=74,HymnName="Praise Ye the Lord"}
                , new Hymn{HymnNumber=75,HymnName="In Hymns of Praise"}
                , new Hymn{HymnNumber=76,HymnName="God of Our Fathers, We Come unto Thee"}
                , new Hymn{HymnNumber=77,HymnName="Great Is the Lord"}
                , new Hymn{HymnNumber=78,HymnName="God of Our Fathers, Whose Almighty Hand"}
                , new Hymn{HymnNumber=79,HymnName="With All the Power of Heart and Tongue"}
                , new Hymn{HymnNumber=80,HymnName="God of Our Fathers, Known of Old"}
                , new Hymn{HymnNumber=81,HymnName="Press Forward, Saints"}
                , new Hymn{HymnNumber=82,HymnName="For All the Saints"}
                , new Hymn{HymnNumber=83,HymnName="Guide Us, O Thou Great Jehovah"}
                , new Hymn{HymnNumber=84,HymnName="Faith of Our Fathers"}
                , new Hymn{HymnNumber=85,HymnName="How Firm a Foundation"}
                , new Hymn{HymnNumber=86,HymnName="How Great Thou Art*"}
                , new Hymn{HymnNumber=87,HymnName="God Is Love"}
                , new Hymn{HymnNumber=88,HymnName="Great God, Attend While Zion Sings"}
                , new Hymn{HymnNumber=89,HymnName="The Lord Is My Light"}
                , new Hymn{HymnNumber=90,HymnName="From All That Dwell below the Skies"}
                , new Hymn{HymnNumber=91,HymnName="Father, Thy Children to Thee Now Raise"}
                , new Hymn{HymnNumber=92,HymnName="For the Beauty of the Earth"}
                , new Hymn{HymnNumber=93,HymnName="Prayer of Thanksgiving"}
                , new Hymn{HymnNumber=94,HymnName="Come, Ye Thankful People"}
                , new Hymn{HymnNumber=95,HymnName="Now Thank We All Our God"}
                , new Hymn{HymnNumber=96,HymnName="Dearest Children, God Is Near You"}
                , new Hymn{HymnNumber=97,HymnName="Lead, Kindly Light"}
                , new Hymn{HymnNumber=98,HymnName="I Need Thee Every Hour"}
                , new Hymn{HymnNumber=99,HymnName="Nearer, Dear Savior, to Thee"}
                , new Hymn{HymnNumber=100,HymnName="Nearer, My God, to Thee"}
                , new Hymn{HymnNumber=101,HymnName="Guide Me to Thee"}
                , new Hymn{HymnNumber=102,HymnName="Jesus, Lover of My Soul"}
                , new Hymn{HymnNumber=103,HymnName="Precious Savior, Dear Redeemer"}
                , new Hymn{HymnNumber=104,HymnName="Jesus, Savior, Pilot Me"}
                , new Hymn{HymnNumber=105,HymnName="Master, the Tempest Is Raging"}
                , new Hymn{HymnNumber=106,HymnName="God Speed the Right"}
                , new Hymn{HymnNumber=107,HymnName="Lord, Accept Our True Devotion"}
                , new Hymn{HymnNumber=108,HymnName="The Lord Is My Shepherd"}
                , new Hymn{HymnNumber=109,HymnName="The Lord My Pasture Will Prepare"}
                , new Hymn{HymnNumber=110,HymnName="Cast Thy Burden upon the Lord"}
                , new Hymn{HymnNumber=111,HymnName="Rock of Ages"}
                , new Hymn{HymnNumber=112,HymnName="Savior, Redeemer of My Soul"}
                , new Hymn{HymnNumber=113,HymnName="Our Savior’s Love"}
                , new Hymn{HymnNumber=114,HymnName="Come unto Him"}
                , new Hymn{HymnNumber=115,HymnName="Come, Ye Disconsolate"}
                , new Hymn{HymnNumber=116,HymnName="Come, Follow Me"}
                , new Hymn{HymnNumber=117,HymnName="Come unto Jesus"}
                , new Hymn{HymnNumber=118,HymnName="Ye Simple Souls Who Stray"}
                , new Hymn{HymnNumber=119,HymnName="Come, We That Love the Lord"}
                , new Hymn{HymnNumber=120,HymnName="Lean on My Ample Arm"}
                , new Hymn{HymnNumber=121,HymnName="I’m a Pilgrim, I’m a Stranger"}
                , new Hymn{HymnNumber=122,HymnName="Though Deepening Trials"}
                , new Hymn{HymnNumber=123,HymnName="Oh, May My Soul Commune with Thee"}
                , new Hymn{HymnNumber=124,HymnName="Be Still, My Soul"}
                , new Hymn{HymnNumber=125,HymnName="How Gentle God’s Commands"}
                , new Hymn{HymnNumber=126,HymnName="How Long, O Lord Most Holy and True"}
                , new Hymn{HymnNumber=127,HymnName="Does the Journey Seem Long?"}
                , new Hymn{HymnNumber=128,HymnName="When Faith Endures"}
                , new Hymn{HymnNumber=129,HymnName="Where Can I Turn for Peace?"}
                , new Hymn{HymnNumber=130,HymnName="Be Thou Humble"}
                , new Hymn{HymnNumber=131,HymnName="More Holiness Give Me"}
                , new Hymn{HymnNumber=132,HymnName="God Is in His Holy Temple"}
                , new Hymn{HymnNumber=133,HymnName="Father in Heaven"}
                , new Hymn{HymnNumber=134,HymnName="I Believe in Christ"}
                , new Hymn{HymnNumber=135,HymnName="My Redeemer Lives"}
                , new Hymn{HymnNumber=136,HymnName="I Know That My Redeemer Lives"}
                , new Hymn{HymnNumber=137,HymnName="Testimony"}
                , new Hymn{HymnNumber=138,HymnName="Bless Our Fast, We Pray"}
                , new Hymn{HymnNumber=139,HymnName="In Fasting We Approach Thee"}
                , new Hymn{HymnNumber=140,HymnName="Did You Think to Pray?"}
                , new Hymn{HymnNumber=141,HymnName="Jesus, the Very Thought of Thee"}
                , new Hymn{HymnNumber=142,HymnName="Sweet Hour of Prayer"}
                , new Hymn{HymnNumber=143,HymnName="Let the Holy Spirit Guide"}
                , new Hymn{HymnNumber=144,HymnName="Secret Prayer"}
                , new Hymn{HymnNumber=145,HymnName="Prayer Is the Soul’s Sincere Desire"}
                , new Hymn{HymnNumber=146,HymnName="Gently Raise the Sacred Strain"}
                , new Hymn{HymnNumber=147,HymnName="Sweet Is the Work"}
                , new Hymn{HymnNumber=148,HymnName="Sabbath Day"}
                , new Hymn{HymnNumber=149,HymnName="As the Dew from Heaven Distilling"}
                , new Hymn{HymnNumber=150,HymnName="O Thou Kind and Gracious Father"}
                , new Hymn{HymnNumber=151,HymnName="We Meet, Dear Lord"}
                , new Hymn{HymnNumber=152,HymnName="God Be with You Till We Meet Again"}
                , new Hymn{HymnNumber=153,HymnName="Lord, We Ask Thee Ere We Part"}
                , new Hymn{HymnNumber=154,HymnName="Father, This Hour Has Been One of Joy"}
                , new Hymn{HymnNumber=155,HymnName="We Have Partaken of Thy Love"}
                , new Hymn{HymnNumber=156,HymnName="Sing We Now at Parting"}
                , new Hymn{HymnNumber=157,HymnName="Thy Spirit, Lord, Has Stirred Our Souls"}
                , new Hymn{HymnNumber=158,HymnName="Before Thee, Lord, I Bow My Head"}
                , new Hymn{HymnNumber=159,HymnName="Now the Day Is Over"}
                , new Hymn{HymnNumber=160,HymnName="Softly Now the Light of Day"}
                , new Hymn{HymnNumber=161,HymnName="The Lord Be with Us"}
                , new Hymn{HymnNumber=162,HymnName="Lord, We Come before Thee Now"}
                , new Hymn{HymnNumber=163,HymnName="Lord, Dismiss Us with Thy Blessing"}
                , new Hymn{HymnNumber=164,HymnName="Great God, to Thee My Evening Song"}
                , new Hymn{HymnNumber=165,HymnName="Abide with Me; ’Tis Eventide"}
                , new Hymn{HymnNumber=166,HymnName="Abide with Me!"}
                , new Hymn{HymnNumber=167,HymnName="Come, Let Us Sing an Evening Hymn"}
                , new Hymn{HymnNumber=168,HymnName="As the Shadows Fall"}
                , new Hymn{HymnNumber=169,HymnName="As Now We Take the Sacrament"}
                , new Hymn{HymnNumber=170,HymnName="God, Our Father, Hear Us Pray"}
                , new Hymn{HymnNumber=171,HymnName="With Humble Heart"}
                , new Hymn{HymnNumber=172,HymnName="In Humility, Our Savior"}
                , new Hymn{HymnNumber=173,HymnName="While of These Emblems We Partake"}
                , new Hymn{HymnNumber=174,HymnName="While of These Emblems We Partake"}
                , new Hymn{HymnNumber=175,HymnName="O God, the Eternal Father"}
                , new Hymn{HymnNumber=176,HymnName="’Tis Sweet to Sing the Matchless Love"}
                , new Hymn{HymnNumber=177,HymnName="’Tis Sweet to Sing the Matchless Love"}
                , new Hymn{HymnNumber=178,HymnName="O Lord of Hosts"}
                , new Hymn{HymnNumber=179,HymnName="Again, Our Dear Redeeming Lord"}
                , new Hymn{HymnNumber=180,HymnName="Father in Heaven, We Do Believe"}
                , new Hymn{HymnNumber=181,HymnName="Jesus of Nazareth, Savior and King"}
                , new Hymn{HymnNumber=182,HymnName="We’ll Sing All Hail to Jesus’ Name"}
                , new Hymn{HymnNumber=183,HymnName="In Remembrance of Thy Suffering"}
                , new Hymn{HymnNumber=184,HymnName="Upon the Cross of Calvary"}
                , new Hymn{HymnNumber=185,HymnName="Reverently and Meekly Now"}
                , new Hymn{HymnNumber=186,HymnName="Again We Meet around the Board"}
                , new Hymn{HymnNumber=187,HymnName="God Loved Us, So He Sent His Son"}
                , new Hymn{HymnNumber=188,HymnName="Thy Will, O Lord, Be Done"}
                , new Hymn{HymnNumber=189,HymnName="O Thou, Before the World Began"}
                , new Hymn{HymnNumber=190,HymnName="In Memory of the Crucified"}
                , new Hymn{HymnNumber=191,HymnName="Behold the Great Redeemer Die"}
                , new Hymn{HymnNumber=192,HymnName="He Died! The Great Redeemer Died"}
                , new Hymn{HymnNumber=193,HymnName="I Stand All Amazed"}
                , new Hymn{HymnNumber=194,HymnName="There Is a Green Hill Far Away"}
                , new Hymn{HymnNumber=195,HymnName="How Great the Wisdom and the Love"}
                , new Hymn{HymnNumber=196,HymnName="Jesus, Once of Humble Birth"}
                , new Hymn{HymnNumber=197,HymnName="O Savior, Thou Who Wearest a Crown"}
                , new Hymn{HymnNumber=198,HymnName="That Easter Morn"}
                , new Hymn{HymnNumber=199,HymnName="He Is Risen!"}
                , new Hymn{HymnNumber=200,HymnName="Christ the Lord Is Risen Today"}
                , new Hymn{HymnNumber=201,HymnName="Joy to the World"}
                , new Hymn{HymnNumber=202,HymnName="Oh, Come, All Ye Faithful"}
                , new Hymn{HymnNumber=203,HymnName="Angels We Have Heard on High"}
                , new Hymn{HymnNumber=204,HymnName="Silent Night"}
                , new Hymn{HymnNumber=205,HymnName="Once in Royal David’s City"}
                , new Hymn{HymnNumber=206,HymnName="Away in a Manger"}
                , new Hymn{HymnNumber=207,HymnName="It Came upon the Midnight Clear"}
                , new Hymn{HymnNumber=208,HymnName="O Little Town of Bethlehem"}
                , new Hymn{HymnNumber=209,HymnName="Hark! The Herald Angels Sing"}
                , new Hymn{HymnNumber=210,HymnName="With Wondering Awe"}
                , new Hymn{HymnNumber=211,HymnName="While Shepherds Watched Their Flocks"}
                , new Hymn{HymnNumber=212,HymnName="Far, Far Away on Judea’s Plains"}
                , new Hymn{HymnNumber=213,HymnName="The First Noel"}
                , new Hymn{HymnNumber=214,HymnName="I Heard the Bells on Christmas Day"}
                , new Hymn{HymnNumber=215,HymnName="Ring Out, Wild Bells"}
                , new Hymn{HymnNumber=216,HymnName="We Are Sowing"}
                , new Hymn{HymnNumber=217,HymnName="Come, Let Us Anew"}
                , new Hymn{HymnNumber=218,HymnName="We Give Thee But Thine Own"}
                , new Hymn{HymnNumber=219,HymnName="Because I Have Been Given Much*"}
                , new Hymn{HymnNumber=220,HymnName="Lord, I Would Follow Thee"}
                , new Hymn{HymnNumber=221,HymnName="Dear to the Heart of the Shepherd"}
                , new Hymn{HymnNumber=222,HymnName="Hear Thou Our Hymn, O Lord"}
                , new Hymn{HymnNumber=223,HymnName="Have I Done Any Good?"}
                , new Hymn{HymnNumber=224,HymnName="I Have Work Enough to Do"}
                , new Hymn{HymnNumber=225,HymnName="We Are Marching On to Glory"}
                , new Hymn{HymnNumber=226,HymnName="Improve the Shining Moments"}
                , new Hymn{HymnNumber=227,HymnName="There Is Sunshine in My Soul Today"}
                , new Hymn{HymnNumber=228,HymnName="You Can Make the Pathway Bright"}
                , new Hymn{HymnNumber=229,HymnName="Today, While the Sun Shines"}
                , new Hymn{HymnNumber=230,HymnName="Scatter Sunshine"}
                , new Hymn{HymnNumber=231,HymnName="Father, Cheer Our Souls Tonight"}
                , new Hymn{HymnNumber=232,HymnName="Let Us Oft Speak Kind Words"}
                , new Hymn{HymnNumber=233,HymnName="Nay, Speak No Ill"}
                , new Hymn{HymnNumber=234,HymnName="Jesus, Mighty King in Zion"}
                , new Hymn{HymnNumber=235,HymnName="Should You Feel Inclined to Censure"}
                , new Hymn{HymnNumber=236,HymnName="Lord, Accept into Thy Kingdom"}
                , new Hymn{HymnNumber=237,HymnName="Do What Is Right"}
                , new Hymn{HymnNumber=238,HymnName="Behold Thy Sons and Daughters, Lord"}
                , new Hymn{HymnNumber=239,HymnName="Choose the Right"}
                , new Hymn{HymnNumber=240,HymnName="Know This, That Every Soul Is Free"}
                , new Hymn{HymnNumber=241,HymnName="Count Your Blessings"}
                , new Hymn{HymnNumber=242,HymnName="Praise God, from Whom All Blessings Flow"}
                , new Hymn{HymnNumber=243,HymnName="Let Us All Press On"}
                , new Hymn{HymnNumber=244,HymnName="Come Along, Come Along"}
                , new Hymn{HymnNumber=245,HymnName="This House We Dedicate to Thee"}
                , new Hymn{HymnNumber=246,HymnName="Onward, Christian Soldiers"}
                , new Hymn{HymnNumber=247,HymnName="We Love Thy House, O God"}
                , new Hymn{HymnNumber=248,HymnName="Up, Awake, Ye Defenders of Zion"}
                , new Hymn{HymnNumber=249,HymnName="Called to Serve"}
                , new Hymn{HymnNumber=250,HymnName="We Are All Enlisted"}
                , new Hymn{HymnNumber=251,HymnName="Behold! A Royal Army"}
                , new Hymn{HymnNumber=252,HymnName="Put Your Shoulder to the Wheel"}
                , new Hymn{HymnNumber=253,HymnName="Like Ten Thousand Legions Marching"}
                , new Hymn{HymnNumber=254,HymnName="True to the Faith"}
                , new Hymn{HymnNumber=255,HymnName="Carry On"}
                , new Hymn{HymnNumber=256,HymnName="As Zion’s Youth in Latter Days"}
                , new Hymn{HymnNumber=257,HymnName="Rejoice! A Glorious Sound Is Heard"}
                , new Hymn{HymnNumber=258,HymnName="O Thou Rock of Our Salvation"}
                , new Hymn{HymnNumber=259,HymnName="Hope of Israel"}
                , new Hymn{HymnNumber=260,HymnName="Who’s on the Lord’s Side?"}
                , new Hymn{HymnNumber=261,HymnName="Thy Servants Are Prepared"}
                , new Hymn{HymnNumber=262,HymnName="Go, Ye Messengers of Glory"}
                , new Hymn{HymnNumber=263,HymnName="Go Forth with Faith"}
                , new Hymn{HymnNumber=264,HymnName="Hark, All Ye Nations!"}
                , new Hymn{HymnNumber=265,HymnName="Arise, O God, and Shine"}
                , new Hymn{HymnNumber=266,HymnName="The Time Is Far Spent"}
                , new Hymn{HymnNumber=267,HymnName="How Wondrous and Great"}
                , new Hymn{HymnNumber=268,HymnName="Come, All Whose Souls Are Lighted"}
                , new Hymn{HymnNumber=269,HymnName="Jehovah, Lord of Heaven and Earth"}
                , new Hymn{HymnNumber=270,HymnName="I’ll Go Where You Want Me to Go"}
                , new Hymn{HymnNumber=271,HymnName="Oh, Holy Words of Truth and Love"}
                , new Hymn{HymnNumber=272,HymnName="Oh Say, What Is Truth?"}
                , new Hymn{HymnNumber=273,HymnName="Truth Reflects upon Our Senses"}
                , new Hymn{HymnNumber=274,HymnName="The Iron Rod"}
                , new Hymn{HymnNumber=275,HymnName="Men Are That They Might Have Joy"}
                , new Hymn{HymnNumber=276,HymnName="Come Away to the Sunday School"}
                , new Hymn{HymnNumber=277,HymnName="As I Search the Holy Scriptures"}
                , new Hymn{HymnNumber=278,HymnName="Thanks for the Sabbath School"}
                , new Hymn{HymnNumber=279,HymnName="Thy Holy Word"}
                , new Hymn{HymnNumber=280,HymnName="Welcome, Welcome, Sabbath Morning"}
                , new Hymn{HymnNumber=281,HymnName="Help Me Teach with Inspiration*"}
                , new Hymn{HymnNumber=282,HymnName="We Meet Again in Sabbath School"}
                , new Hymn{HymnNumber=283,HymnName="The Glorious Gospel Light Has Shone"}
                , new Hymn{HymnNumber=284,HymnName="If You Could Hie to Kolob"}
                , new Hymn{HymnNumber=285,HymnName="God Moves in a Mysterious Way"}
                , new Hymn{HymnNumber=286,HymnName="Oh, What Songs of the Heart"}
                , new Hymn{HymnNumber=287,HymnName="Rise, Ye Saints, and Temples Enter"}
                , new Hymn{HymnNumber=288,HymnName="How Beautiful Thy Temples, Lord"}
                , new Hymn{HymnNumber=289,HymnName="Holy Temples on Mount Zion"}
                , new Hymn{HymnNumber=290,HymnName="Rejoice, Ye Saints of Latter Days"}
                , new Hymn{HymnNumber=291,HymnName="Turn Your Hearts"}
                , new Hymn{HymnNumber=292,HymnName="O My Father"}
                , new Hymn{HymnNumber=293,HymnName="Each Life That Touches Ours for Good"}
                , new Hymn{HymnNumber=294,HymnName="Love at Home"}
                , new Hymn{HymnNumber=295,HymnName="O Love That Glorifies the Son"}
                , new Hymn{HymnNumber=296,HymnName="Our Father, by Whose Name"}
                , new Hymn{HymnNumber=297,HymnName="From Homes of Saints Glad Songs Arise"}
                , new Hymn{HymnNumber=298,HymnName="Home Can Be a Heaven on Earth"}
                , new Hymn{HymnNumber=299,HymnName="Children of Our Heavenly Father*"}
                , new Hymn{HymnNumber=300,HymnName="Families Can Be Together Forever"}
                , new Hymn{HymnNumber=301,HymnName="I Am a Child of God"}
                , new Hymn{HymnNumber=302,HymnName="I Know My Father Lives"}
                , new Hymn{HymnNumber=303,HymnName="Keep the Commandments"}
                , new Hymn{HymnNumber=304,HymnName="Teach Me to Walk in the Light"}
                , new Hymn{HymnNumber=305,HymnName="The Light Divine"}
                , new Hymn{HymnNumber=306,HymnName="God’s Daily Care"}
                , new Hymn{HymnNumber=307,HymnName="In Our Lovely Deseret"}
                , new Hymn{HymnNumber=308,HymnName="Love One Another"}
                , new Hymn{HymnNumber=309,HymnName="As Sisters in Zion"}
                , new Hymn{HymnNumber=310,HymnName="A Key Was Turned in Latter Days"}
                , new Hymn{HymnNumber=311,HymnName="We Meet Again as Sisters"}
                , new Hymn{HymnNumber=312,HymnName="We Ever Pray for Thee"}
                , new Hymn{HymnNumber=313,HymnName="God Is Love"}
                , new Hymn{HymnNumber=314,HymnName="How Gentle God’s Commands"}
                , new Hymn{HymnNumber=315,HymnName="Jesus, the Very Thought of Thee"}
                , new Hymn{HymnNumber=316,HymnName="The Lord Is My Shepherd"}
                , new Hymn{HymnNumber=317,HymnName="Sweet Is the Work"}
                , new Hymn{HymnNumber=318,HymnName="Love at Home"}
                , new Hymn{HymnNumber=319,HymnName="Ye Elders of Israel"}
                , new Hymn{HymnNumber=320,HymnName="The Priesthood of Our Lord"}
                , new Hymn{HymnNumber=321,HymnName="Ye Who Are Called to Labor"}
                , new Hymn{HymnNumber=322,HymnName="Come, All Ye Sons of God"}
                , new Hymn{HymnNumber=323,HymnName="Rise Up, O Men of God"}
                , new Hymn{HymnNumber=324,HymnName="Rise Up, O Men of God"}
                , new Hymn{HymnNumber=325,HymnName="See the Mighty Priesthood Gathered"}
                , new Hymn{HymnNumber=326,HymnName="Come, Come, Ye Saints"}
                , new Hymn{HymnNumber=327,HymnName="Go, Ye Messengers of Heaven"}
                , new Hymn{HymnNumber=328,HymnName="An Angel from on High"}
                , new Hymn{HymnNumber=329,HymnName="Thy Servants Are Prepared"}
                , new Hymn{HymnNumber=330,HymnName="See, the Mighty Angel Flying"}
                , new Hymn{HymnNumber=331,HymnName="Oh Say, What Is Truth?"}
                , new Hymn{HymnNumber=332,HymnName="Come, O Thou King of Kings"}
                , new Hymn{HymnNumber=333,HymnName="High on the Mountain Top"}
                , new Hymn{HymnNumber=334,HymnName="I Need Thee Every Hour"}
                , new Hymn{HymnNumber=335,HymnName="Brightly Beams Our Father’s Mercy"}
                , new Hymn{HymnNumber=336,HymnName="School Thy Feelings"}
                , new Hymn{HymnNumber=337,HymnName="O Home Beloved"}
                , new Hymn{HymnNumber=338,HymnName="America the Beautiful"}
                , new Hymn{HymnNumber=339,HymnName="My Country, ’Tis of Thee"}
                , new Hymn{HymnNumber=340,HymnName="The Star-Spangled Banner"}
                , new Hymn{HymnNumber=341,HymnName="God Save the King"}

            };
            return list;
        }
    }
}
