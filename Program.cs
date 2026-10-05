namespace OsnoveCSharp5_API2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            // Pimer statickog rutiranja:
            app.MapGet("/", () => "Hello World!");

            //Primeri dinamickog rutiranja -
            // 1. Ruta koja prihvata odredjene parametre:
            app.MapGet("/korisnici/{korisnikID}/postovi/{skracenicaNazivaPosta}", (int korisnikID, string skracenicaNazivaPosta) =>
            {
                return $"Korisnicki ID je: {korisnikID}, Skracenica posta: {skracenicaNazivaPosta}";
            } 
            );

            // 2. Primeri rute sa ogranicenjima:
            app.MapGet("/proizvodi/{proizvodID:int:min(0)}", (int proizvodID) =>
            {
                return $"Proizvod ima ID: {proizvodID}";
            }
            );
            // 3. Primer rute sa opcionim parametrom, koriscenjem ?:
            app.MapGet("/izvestaji/{godina?}", (int? godina = 2020)  =>
            {
                return $"Godina izvestaja: {godina}";
                ;
            }
            );
            // 4. Primer rute koriscenjem wildcard znakova:
            app.MapGet(
                "/recepti/{*sviRecepti}", (string sviRecepti) =>
                {
                    return $"Putanja do recepata: {sviRecepti}";
                }
             );
            // 5. Primer rute za pretrazivanje i prosledjivanje vrednosti promenljive(argumenta) putem URL u zahtevi.http:
            app.MapGet(
                "/pretraga", (string? upit, int stranica = 1) =>
                {
                    return $"Pretraga za: {upit} na stranici: {stranica}";
                }
             );
            // 6. Kombinacija svega do sada:
            app.MapGet(
             "/prodavnica/{kategorije}/{proizvodID:int?}/{*putanja}", (string kategorije, int? proizvodID, string? putanja, bool dostupan = true ) => 
             {
                 return $"Kategorija proizvoda: {kategorije}";
                 
             }   
             );

            app.Run();
        }
    }
}
