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

// Partie 2 :  Surcharge des opérateurs

//Test de la surcharge de l'opérateur + pour les médias
//Les livres
Console.WriteLine("Test de la surcharge de l'opérateur + pour les médias");
Console.WriteLine("Les livres");
Livre unLivre2 = new Livre("ça",4,9,"Stephen King","Thriller");
unLivre = unLivre + unLivre2;
unLivre.AfficherInfos();

Console.WriteLine("\n");

//Les CDs
Console.WriteLine("Les CDs");
CD unCD2 = new CD("Civilisation",5,2,"Orelsan","Warner");
unCD = unCD + unCD2;
unCD.AfficherInfos();

Console.WriteLine("\n");

//Les DVDs
Console.WriteLine("Les DVDs");
DVD unDVD2 = new DVD("Narnia",2,5,2.20,"Andrew Adamson");
unDVD = unDVD + unDVD2;
unDVD.AfficherInfos();

Console.WriteLine("\n");

//Test de la surcharge de l'opérateur - pour les médias
//Les livres
Console.WriteLine("Test de la surcharge de l'opérateur - pour les médias");
Console.WriteLine("Les livres");
unLivre = unLivre - unLivre2;
unLivre.AfficherInfos();

Console.WriteLine("\n");

//Les CDs
Console.WriteLine("Les CDs");
unCD = unCD - unCD2;
unCD.AfficherInfos();
    
Console.WriteLine("\n");

//Les DVDs
Console.WriteLine("Les DVDs");
unDVD = unDVD - unDVD2;
unDVD.AfficherInfos();

Console.WriteLine("\n");

// Partie 3 : Collections et Indexeurs

Library maBibliotheque = new Library();

//Ajout de médias
maBibliotheque.AjouterMedia(unLivre);
maBibliotheque.AjouterMedia(unDVD);

maBibliotheque.AfficherStatistiques();

//Test de l'indexeur
Console.WriteLine("Test de l'indexeur");

//Emprunter un média
maBibliotheque.EmprunterMedia(4);

//Retirer un média
maBibliotheque.RetirerMedia(4);

maBibliotheque.AfficherStatistiques();

//Partie 4 : Sérialisation JSON
// Sauvegarde de la bibliothèque
string cheminFichier = "bibliotheque.json";
maBibliotheque.SauvegarderBibliotheque(cheminFichier);
Console.WriteLine("Bibliothèque sauvegardée.");

// Chargement de la bibliothèque
Library bibliothequeChargee = Library.ChargerBibliotheque(cheminFichier);
Console.WriteLine("Bibliothèque chargée.");
bibliothequeChargee.AfficherStatistiques();



