using System;

/*
 * 
 * Créer un premier programme console qui va décrire la situation suivante :
[1] Un spectateur croise deux dresseurs de singes. Chaque dresseur a un singe.
[2] Chaque singe connaît une liste de tours, qui ont chacun un nom et sont soit des
tours d'acrobatie ou de musique
[3] Les dresseurs peuvent demander à leur singe d'exécuter un tour.
[4] Le spectateur applaudit lors de tours d'acrobatie ou siffle pendant les tours demusique.
Avec les contraintes suivantes :
[1] Spectateur, singe et dresseur sont des classes.
[2] Le programme doit créer une instance du spectateur, deux instances de dresseurs et deux
instances de singe
[3] Chaque dresseur demande à son singe d'exécuter tous ses tours.
[4] Le spectateur réagit aux tours.
[5] Le programme devra afficher des messages du type "spectateur applaudit pendant le tour
d'acrobatie 'marcher sur les mains' du singe 2".
[6] Faites très attention au modèle objet et au couplage faible, le singe ne peut pas appeler la
méthode Applaudit du spectateur !
2) Créer un second programme console qui va :
[1] créer des HtmlControls dynamiquement (avec la classe System.Web.UI.HtmlGenericControl
), codés en durs. Peu importe quelles balises, il faut avoir une profondeur de trois ou quatre
contrôles dans l'arbre.
[2] écrire une fonction qui va rechercher un contrôle ayant un certain nom.

 */
namespace MonkeTrainers
{
	class Program
	{
		static void Main(string[] args)
		{
			Trainer trainer1 = new Trainer(new Monkey("1"));
			Trainer trainer2 = new Trainer(new Monkey("2"));

			Spectator spectator = new Spectator();

			trainer1.Init();
			trainer2.Init();

			for (int i = 0; i < 5; i++)
			{

				trainer1.PerformTrick(i, (trick) => TrickReaction(trick, spectator));
				trainer2.PerformTrick(i, (trick) => TrickReaction(trick, spectator));

			}
		}

		static void TrickReaction(Trick trick, Spectator spectator)
		{
			ReactionType reaction = spectator.ReactToTrick(trick.TrickType);
			Console.WriteLine("Le spectateur {0} au tour {1} {2} du singe {3}", reaction.ToString(), trick.TrickType.ToString(), trick.TrickName, trick.TrickPerformer.GetName());
		}
	}
}
