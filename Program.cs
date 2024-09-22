using Gestion_Biblio_Media;

// Partie 1 : Classes, Héritage et Polymorphisme

Livre m_unLivre = new Livre("Ca",4,7,"Stephen King","Thriller");
DVD m_unDVD = new DVD("Narnia",2,3,2.20,"Andrew Adamson");
CD m_unCD = new CD("Civilisation",5,24,"Orelsan","Warner");

m_unLivre.AfficherInfos();
Console.WriteLine("\n");
m_unDVD.AfficherInfos();
Console.WriteLine("\n");
m_unCD.AfficherInfos();
Console.WriteLine("\n");

// Partie 2 : Surcharge des opérateurs

//Les livres
Console.WriteLine("Test de la surcharge de l'opérateur + pour les médias");
Console.WriteLine("Les livres");
Livre m_unLivre2 = new Livre("Ca",4,9,"Stephen King","Thriller");
m_unLivre.AfficherInfos();

Console.WriteLine("\n");

//Les CDs
Console.WriteLine("Les CDs");
CD m_unCD2 = new CD("Civilisation",5,2,"Orelsan","Warner");
m_unCD.AfficherInfos();

Console.WriteLine("\n");

//Les DVDs
Console.WriteLine("Les DVDs");
DVD m_unDVD2 = new DVD("Narnia",2,5,2.20,"Andrew Adamson");
m_unDVD.AfficherInfos();

Console.WriteLine("\n");

//Les livres
Console.WriteLine("Test de la surcharge de l'opérateur - pour les médias");
Console.WriteLine("Les livres");
m_unLivre.AfficherInfos();

Console.WriteLine("\n");

//Les CDs
Console.WriteLine("Les CDs");
m_unCD.AfficherInfos();
    
Console.WriteLine("\n");

//Les DVDs
Console.WriteLine("Les DVDs");
m_unDVD.AfficherInfos();

Console.WriteLine("\n");

// Partie 3 : Collections et Indexeurs

Library m_maBibliotheque = new Library();

//Ajout de médias
m_maBibliotheque.AjouterMedia(m_unLivre);
m_maBibliotheque.AjouterMedia(m_unDVD);

m_maBibliotheque.AfficherStatistiques();

//Test de l'indexeur
Console.WriteLine("Test de l'indexeur");

//Emprunter un média
m_maBibliotheque.EmprunterMedia(4, "Jean");

//Retirer un média
//m_maBibliotheque.RetirerMedia(4);

m_maBibliotheque.AfficherStatistiques();

//Partie 4 : Sérialisation JSON
// Sauvegarde de la bibliothèque
string m_cheminFichier = "bibliotheque.json";
m_maBibliotheque.SauvegarderBibliotheque(m_cheminFichier);
Console.WriteLine("Bibliothèque sauvegardée.");

// Chargement de la bibliothèque
Library bibliothequeChargee = Library.ChargerBibliotheque(m_cheminFichier);
Console.WriteLine("Bibliothèque chargée.");
bibliothequeChargee.AfficherStatistiques();



