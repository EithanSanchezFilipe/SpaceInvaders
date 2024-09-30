using Drones.Helpers;

namespace Drones
{
    // Cette partie de la classe Drone définit comment on peut voir un drone
    public partial class Drone
    {
        private Pen droneBrush = new Pen(new SolidBrush(Color.Purple), 3);
        private Image droneImage; // Champ pour stocker l'image du droneprivate 


        // Méthode pour charger l'image du drone (à appeler manuellement après création du drone)
        public void LoadDroneImage()
        {
            try
            {
                // Charger l'image du drone depuis un fichier (imagePath fourni en argument)
                droneImage = Image.FromFile("C:\\Users\\pa78gum\\Documents\\GitHub\\SpaceInvaders\\POO\\zombie.png");
                Console.WriteLine("image loaded");
            }
            catch (Exception ex)
            {
                // Gestion des erreurs en cas d'échec du chargement de l'image
                Console.WriteLine("Erreur lors du chargement de l'image : " + ex.Message);
                droneImage = null; // Définit l'image à null si elle n'est pas chargée correctement
            }
        }

        // Méthode de rendu graphique
        public void Render(BufferedGraphics drawingSpace)
        {

                Console.WriteLine("image loaded");
                // Dessiner l'image du drone centrée sur la position (X, Y)
                drawingSpace.Graphics.DrawImage(droneImage, X - droneImage.Width / 2, Y - droneImage.Height / 2);


            // Dessiner le texte avec le nom et le pourcentage de charge
        }
    }
}

        // De manière
