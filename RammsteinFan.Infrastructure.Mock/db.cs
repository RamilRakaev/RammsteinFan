using RammsteinFan.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RammsteinFan.Infrastructure.Mock
{
    public static class db
    {
        
        public static List<Replica> Replicas { get; set; } = new List<Replica>()
        {
            new Replica("Саша","Я не знаю, блин",2){Id=3, DiscussionSubjectId=2 },
            new Replica("Данил","Это Тиль",1){Id=4, Comments=1},
            new Replica("Данил","Нет, это Рихард",1, 4){Id=5},
            new Replica("Данил","Это Пауль",1){Id=6, DiscussionSubjectId = 1},
            new Replica("Данил","Это была их любимая игра, и это звучало бростко",3){Id=4},
        };

        public static List<DiscussionSubject> DiscussionSubjects { get; set; } = new List<DiscussionSubject>() 
        { 
            new DiscussionSubject(
                "Участники группы",
                "Кто лидер группы Тиль или Рихард?",
                "Иван",
                "С одной стороны основателем группы является Рихард, с другой Тиль является главным фронтменом.")
            {Id=1, Comments=3, Views=50, Likes=11},
            new DiscussionSubject(
                "Участники группы",
                "Почему к имени Кристофа добавили префикс Doom?",
                "Иван",
                "Пауль предложил добавить к имени ударника Кристофа Шнайдера Doom.")
            {Id=3, Comments=1, Views=12, Likes=3},
            new DiscussionSubject(
                "Символика группы",
                "Логотип",
                "Иван",
                "Откуда взялся логотип группы?")
            {Id=2, Comments=1, Views=32, Likes=23}
        };

        public static List<User> Users { get; set; } = new List<User>()
        {
            new User("Name", 26, "password", "admin")
        };

        public static List<Content> DbContent { get; set; } = new List<Content>()
        {
            new Content("Заголовок","Article", "Index/History", "Текст", false){Id=1},
            new Content("Liebe ist Fur alle da","AlbumTitles", "SongTranslationsMain&AlbumsMain","Rammlied,Ich tu dir weh, Waidmanns Heil, Haifisch, " +
                "B * *******, Fruhling in Paris, Wiener Blut, Pussy, Liebe ist Fur alle da, Mehr,Roter Sand, " +
                "Fuhre mich, Donaukinder, Halt, Liese", false){Id=2 },
            new Content("Mutter","AlbumTitles", "SongTranslationsMain&AlbumsMain","Mein Herz brennt, Links 2 3 4, Sonne, Ich will, Feuer frei!," +
                " Mutter, Spieluhr, Zwitter, Rein raus, Adios, Nebel"){Id=3 },
            new Content("Links 2 3 4","Lyrics", "SongTranslationsMain/Links 2 3 4","Links 2 3 4\n" +
           "\n" +
"Kann man[1] Herzen brechen[2]\n" +
"können Herzen sprechen\n" +
"kann man Herzen quälen\n" +
"kann man Herzen stehlen\n" +
"\n" +
"Sie wollen mein Herz am rechten Fleck[3]\n" +
"doch seh ich dann nach unten weg[4]\n" +
"da schlägt es links[5]\n" +
"Links\n" +
"\n" +
"Können Herzen singen\n" +
"kann ein Herz zerspringen\n" +
"können Herzen rein sein\n" +
"kann ein Herz aus Stein sein\n" +
"\n" +
"Sie wollen mein Herz am rechten Fleck\n" +
"doch seh ich dann nach unten weg\n" +
"da schlägt es links\n" +
"Links(3x)\n" +
"\n" +
"Links zwo drei vier\n" +
"Links zwo(3x) drei vier links(2x)\n" +
"Links zwo drei vier\n" +
"\n" +
"Kann man Herzen fragen\n" +
"ein Kind darunter tragen\n" +
"kann man es verschenken\n" +
"mit dem Herzen denken\n" +
"\n" +
"Sie wollen mein Herz am rechten Fleck\n" +
"doch seh ich dann nach unten weg\n" +
"da schlägt es in der linken Brust\n" +
"der Neider hat es schlecht gewusst[6]\n" +
"\n" +
"Links(4x)\n" +
"Links zwo drei vier links\n" +
"\n" +
"Links zwo drei vier\n" +
"Links zwo(3x) drei vier links(2x)\n" +
"Links zwo(3x) drei vier(4x)\n"){Id=4 },

            new Content("Links 2 3 4","SongTranslation","SongTranslationsMain/Links 2 3 4","Левой, 2 3 4\n" +
"\n" +
"Можно ли[1] сердце разбить?[2]\n" +
"Могут ли сердца говорить?\n" +
"Можно ли сердце мучить?\n" +
"Можно ли сердце украсть?\n" +
"\n" +
"Хотят, чтоб мое сердце было справа[3]\n" +
"Но я опускаю взгляд[4] -\n" +
"оно же бьется слева![5]\n" +
"        Левой!\n" +
"\n" +
"Могут ли сердца петь?\n" +
"Может ли сердце разорваться?\n" +
"Могут ли сердца быть чистыми?\n" +
"Может ли оно быть каменным?\n" +
"\n" +
"Хотят , чтоб мое сердце было справа\n" +
"Но я опускаю взгляд -\n" +
"оно же бьется слева!\n" +
"Левой! (3x)\n" +
"\n" +
"Левой! Два, три, четыре!\n" +
"Левой! Два,(3x) три, четыре! Левой! (2x)\n" +
"Левой! Два, три, четыре!\n" +
"\n" +
"Можно ли спрашивать сердце?\n" +
"Дитя под ним вынашивать?\n" +
"Можно ли его подарить?\n" +
"Можно ли думать сердцем?\n" +
"\n" +
"Хотят, чтоб мое сердце было справа\n" +
"Но я опускаю взгляд -\n" +
"оно же бьется слева!\n" +
"Завистник это плохо знал[6]...\n" +
"\n" +
"Левой! (4x)\n" +
"Левой! Два, три, четыре! Левой!\n" +
"\n" +
"Левой! Два, три, четыре!\n" +
"Левой! Два,(3x) три, четыре! Левой! (2x)\n" +
"Левой! Два,(3x) три, четыре! (2x)\n"){Id=5 },
            new Content("Links 2 3 4","SongDescription","SongTranslationsMain/Links 2 3 4",
                "Перевод Max'a при участии Schwester[1] - kann mann - не испрашивание разрешения. Здесь риторический вопрос " +
                "МОЖНО или НЕЛЬЗЯ? :- ) прим. Max'a[2] - значение ломать по отношению к сердцу не очень подходит... Если оно не " +
                "механическое, то лучше употреблять в переводе русское выражение \"разбить сердце\" - прим. Max'a[3] - " +
                "подразумевается фраза \"окружающим так хочется видеть, что мое сердце справа\" , то есть окружающие жаждут выдать " +
                "желаемое ( с их стороны) за действительность, навесить ярлык , так сказать... ни для кого уже не секрет, что в " +
                "свое время на Раммштайн частенько навешивали ярлык \"наци\", \"фашистов\". Этот текст был написан \"в ответ\" всем " +
                "обвинителям, когда члены группы уже устали опровергать в прессе то, что они - группа \"правого\" толка, этот " +
                "текст - свидетельство того, что Раммштайн никогда не разделяли взглядов \"наци\" - прим. Max'a [4] - фраза " +
                "двоякая... можно опускать глаза от стыда, можно - чтоб удостовериться, что сердце находится там, где ему и " +
                "положено быть - слева :- ) Последнее мне кажется более логичным, хотя кто знает, что Тилль вкладывал в эту " +
                "фразу! ;- ) Фраза - провокация, в стиле Раммштайн- \"А вот и думайте, граждане, что мы имели в виду!...\" - прим. " +
                "Max'a[5] – есть такое выражение: Das Herz am rechten Fleck haben. Оно означает: быть хорошим человеком, честным " +
                "и так далее. В данном случае что мы имеем? Тилль над нами смеется! «Вы думаете, что я хороший человек? Ан-нет, у " +
                "меня сердце слева!» Дело в том, что recht, это и «справа» и «на правильном месте». Вот и думаем... – прим. Schwester"+
                "[6] - То есть - оный завистник не особо вникал в анатомию... Скорее, значение этой строчки - завистники видят только " +
                "то, что ХОТЯТ видеть, не вникая в то, как обстоят дела на самом деле. Они не ЗНАЮТ, они ДУМАЮТ, что знают - прим. Max'a")
            {Id=6 },
            new Content("Mutter","AlbumDescription", "AlbumsMain/Mutter","Mutter (с нем. — «Мать») — третий " +
                "студийный альбом немецкой метал-группы Rammstein,вышел 2 апреля 2001 года. Альбом записывался в " +
                "Германии, Франции, Швеции и Америке.Журнал Metal Hammer включил Mutter в 200 лучших рок-альбомов " +
                "всех времён (в стиле индастриал-метал, 4-е место). В интервью Noizr Zine шведский продюсер и " +
                "музыкант Петер Тэгтгрен посоветовал Mutter в качестве ориентира всем начинающим метал-продюсерам: " +
                "«Он очень хорош, потому что в нём много различных элементов — в нём есть оркестровые партии, " +
                "тяжёлые гитары, хорошее звучание барабанов — он может быть хорошим ориентиром»."){Id=7},
            new Content("Mutter","AlbumWithSongs", "AlbumsMain/Mutter", ""){Id=8},
            new Content("PhotoGalery","PhotoGalery","PhotoGaleryMain","Rammstein - in Moscow 2019, Wallpaper"){Id=9},
            new Content("NumberOfPhotos","NumberOfPhotos","PhotoGaleryMain","Rammstein - in Moscow 2019-01, Wallpaper-12"){Id=10},
            new Content("Rammstein - live in Moscow 2019 (Full concert) [multicam by DarkSun]","Video","VideoGaleryMain",
                "https://www.youtube.com/watch?v=DXm55W4yZPY&t=3s"){Id=11},
            new Content("Rammstein - Rock over Volga festival 2013 (Multicam by VinZ)","Концерты","VideoGaleryMain",
                "https://www.youtube.com/watch?v=pG9fkA_FYGQ"){Id=12},
            new Content("100 Jahre Rammstein (full original VHS rip) [HQ]NEW RIP","Концерты","VideoGaleryMain",
                "https://www.youtube.com/watch?v=gZ-M4XWSNOU&t=1s"){Id=13}
        };
 
        
            
    }
}
