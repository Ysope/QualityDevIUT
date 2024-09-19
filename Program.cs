using Gestion_Biblio_Media;

// Partie 1 : Classes, Héritage et Polymorphisme

Livre unLivre = new Livre("ça",4,7,"Stephen King","Thriller");
DVD unDVD = new DVD("Narnia",2,3,2.20,"Andrew Adamson");
CD unCD = new CD("Civilisation",5,24,"Orelsan","Warner");

unLivre.AfficherInfos();
Console.WriteLine("\n");
unDVD.AfficherInfos();
Console.WriteLine("\n");
unCD.AfficherInfos();
Console.WriteLine("\n");

// Partie 3 : Collections et Indexeurs

