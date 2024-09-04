using Drones.Helpers;

namespace Drones
{
    // Cette partie de la classe Drone définit comment on peut voir un drone
    public partial class Drone
    {
        private Pen droneBrush = new Pen(new SolidBrush(Color.Purple), 3);
        private Image droneImage; // Champ pour stocker l'image du drone

        // Méthode pour charger l'image du drone (à appeler manuellement après création du drone)
        public void LoadDroneImage()
        {
            try
            {
                // Charger l'image du drone depuis un fichier (imagePath fourni en argument)
                droneImage = Image.FromFile("../Model/Vaisseau.png");
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
            if (droneImage != null)
            {
                // Dessiner l'image du drone centrée sur la position (X, Y)
                drawingSpace.Graphics.DrawImage(droneImage, X - droneImage.Width / 2, Y - droneImage.Height / 2);
            }
            else
            {
                // Si l'image n'est pas disponible, dessiner l'ellipse comme avant
                drawingSpace.Graphics.DrawEllipse(droneBrush, new Rectangle(X - 4, Y - 2, 8, 8));
            }

            // Dessiner le texte avec le nom et le pourcentage de charge
            drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, X + 5, Y - 5);
        }
    }
}

        // De manière
