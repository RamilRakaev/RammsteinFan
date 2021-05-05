using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;

namespace RammsteinFan.Pages.UserPages.SongTranslations
{
    public class TranslationSongModel : PageModel
    {
        public void OnGet()
        {
            Songs =textSong.Split("\n").ToList();
            SongTranslations = textSongTranslation.Split("\n").ToList();
        }
        public List<string> Songs { get;set;}
        public List<string> SongTranslations { get;set;}

        string textSong = "Links 2 3 4\n" +
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
"Links zwo(3x) drei vier(4x)\n";
        string textSongTranslation = "Левой, 2 3 4\n" +
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
"Левой! Два,(3x) три, четыре! (2x)\n";
    }
}
