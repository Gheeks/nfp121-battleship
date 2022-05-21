# Battleship
(Projet incomplet ~Peu de front (non noté) -> application faite comme une Api.)

## Liste des fonctionalités (Résumé des développements)
### Comptes utilisateurs : 
  - Administrateurs ✅
  - Joueur ✅
  
  Tous les utilisateurs doivent se connecter avec un couple identifiant / mot de passe. Il est possible de s’inscrire via le site internet. ✅ 
  
Pour s’inscrire, l’adresse mail doit être valide et le mot de passe avec au moins 1 chiffre, 1 caractère spécial et une longueur d’au moins 8 caractères. ✅

### Lancement d’une bataille 
  L’objectif premier et de permettre aux utilisateurs de joueur contre une intelligence artificielle. L’utilisateur pourra choisir 2 niveaux de difficulté : 
   - Facile ✅
   - Moyen ✅

Le déroulement de la partie est le suivant : 
### Placement des bateaux ✅

  Le joueur doit d’abord placer ses bateaux ✅ (Par envoie d'un objet grille au service)
  - 1 de 2 ✅ 
  - 2 de 3 ✅
  - 2 de 4 ✅
  - 1 de 5 ✅
    
  - Sur un plateau de 8 x 8 ✅
  - Les bateaux ne peuvent pas se superposer, ni sortir de la grille. ✅
  - Les bateaux peuvent être posés horizontalement✅, verticalement✅, en diagonale❌ et ne doivent pas être juxtaposés. ❌
  - Déroulement du tour par tour ✅
  - Le premier jour est tiré au sort. ✅
  
  A chaque tour, le joueur sélectionne une case✅. Un message est affiché pour lui indiquer s’il a touché ou non❌. Une vérification doit être faite pour assurer que les coordonnées sont valides (dans la grille et pas déjà attaquées)✅. 
  
  Tant que le joueur arrive à toucher une position✅, il peut continuer à tirer✅, sinon c’est l’IA qui joue son tour❌〰️. 
  
  La partie continue tant que l’un des deux joueurs a encore des bateaux sur son plateau✅. 
  
  A la fin de la partie je joueur peut choisir de recommencer.❌

### Multijoueur❌ (Bonus)
  - Dans un second temps, l’application doit permettre de gérer une partie en Multijoueur (voir signalR pour les communications en temps réel). ❌
  - Un joueur fait une requête à un autre, s’il l’accepte, la partie commence. Il est possible pour un joueur d’arrêter à tout moment. ❌
  - Le tableau des statistiques doit également être mis à jour. ❌

### Logique de l’IA 
  L’IA aura deux modes :
  - Facile ✅
  - Moyen✅
    
Le mode facile se contente de tirer au hasard sur la grille. ✅

Un mode moyen se comporte de la façon suivante : ❌
  - Tire au hasard sur le plateau❌
  - Si le tire ne touche pas, reprendre un tir au hasard ❌
  - Si le tire touche, chercher au hasard dans les point adjacents la continuité du bateau❌
  - Ne pas tirer sur une case qui serait une « juxtaposition » d’un bateau existant ❌
  - A partir du moment où l’on a un alignement de deux points, garder les tirs dans ce même alignement. ❌
  
 
### Mes statistiques ✅
  - Dans son espace personnel, l’utilisateur peut consulter l’historique de ses parties contre l’IA. Récapituler dans un tableau de longueur 10, paginé côté serveur : ✅
  - Le niveau de l’IA (ou le pseudo du joueur en cas de multijoueur)✅
  - Le statut (victoire / défaite)✅
  - Nombre de titre effectués IA ✅
  - Nombre de titre effectués joueur ✅
  - Temps de la partie✅

### Espace administration ✅
  - L’administrateur peut consulter l’historique des parties. Récapituler dans un tableau de longueur 10, paginé côté serveur : ✅
  - Le niveau de l’IA (ou le pseudo du joueur en cas de multijoueur)✅
  - Le pseudo du joueur✅
  - Le statut (victoire / défaite)✅
  - Nombre de titre effectués IA ✅
  - Nombre de titre effectués joueur ✅
  - Temps de la partie✅
  
NOTA: Tous n'est pas appelable par le WebService, certaines méthodes sont faites mais n'ont pas été assemblées.

## Explication des choix techniques

J'ai fait le choix de choisir Angular + .NET pour le front.

### 1. Explication Front/Back
L'idée était d'avoir une application Back qui ressemble au front. (J'ai toujours appris à faire ça comme cela.)

Par exemple:
- Création de la grille: Angular posède un "Models" grid et un "Models" Cell.
Le but était donc de pouvoir effectuer un meilleur contrôle des objets passés du front au back et inversement.
Du coup pour la création de la grille, l'idée était d'initialiser un objet "Grid" directement dans le front pour l'envoyer au back qui aurait fait les vérifications et l'insertion en base.

- Pour les statistiques, il s'agit de la liste des parties, en effet, dans l'idée que Angular possède les modèles, il est du coup possible d'effectuer les traitements facilement dans Angular.
Pour ce qui est de la pagination côté serveur, en utilisant AG-Grid par exemple, il est possible d'envoyer la dernière taille de ligne récupérée.

### 2. L'application.

Elle a été conçue au maximum en TDD (sauf sur la fin), il n'était pas possible de tricher du fait que le front n'était pas là, il fallait absolument que j'aie une stratégie de tests me permettant de constituer des objets corrects.

#### 2.1 Services

- J'ai fait le choix de créer un Singleton pour le "GameService" qui va instancier les autres services afin de pouvoir les utiliser partout dans l'Application. En effet, ce service étant un point d'accès central, il interagit avec différents services. Par conséquent, il n'y aurait pas de sens de réinstancier X fois les services.
- Au niveau de l'IA, il s'agit d'une fonction récursive afin de placer les bateaux (même si en termes de performance cela n'est pas optimum).
- Au niveau de la grille, le service à en charge de vérifier toutes les actions qu'on fait dessus (responsabilité d'elle-même)
- Concernant du joueur, il s'agit du login, il gère les joueurs dans la partie et les créations de compte.
- Enfin, le service de stats permet juste l'initialisation des stats et aurait du permettre leur enregistrement.

#### 2.2 Modèles

- Les bateaux possèdent tous une classe Ship commune sinon chaque bateau possède sa propre classe (modèle builder), leur orientation est une enum (pour laisser ouvertes les modifications).
- Concernant la cellule elles connaissent les bateaux qui les contiennent afin de mieux le maintenir en base et pour les traitements et leur statut est dans une énum.
- La grille possède des fonctions qui auraient dû être très clairement dans le service. En-dehors de ça, elle possède une liste de cellules et un owner. En effet, dans le cas d'une partie, il s'agit de faire deux grilles (et d'aller les récupérer grâce à l'id de la partie).
- Le joueur possède des attributs standard dont un IsAdmin.
- La classe Stats aurait pu s'appeler "Game" et contient toutes les informations pour trouver une partie et retrouver les informations dessus.

#### 2.3 Contrôleurs

- Concernant les contrôleurs, il s'agit d'un gros point d'accès, néanmoins pour les best practices il aurait fallu faire des repositories. En effet, les services possèdent de grosses responsabilités. (dont l'appel à d'autres service, ce qui est plus à faire dans des repositories)
J'ai essayé de mettre des try/catch en partant du principe que la gestion d'erreur se fait côté front également. 
- Le contrôleur de grille, permet de créer une nouvelle partie avec une IA. Il suffit de lui envoyer une grille et il va créer une partie en retournant la grille de l'adversaire. C'est donc au front de faire un pré-contrôle sur le nombre de bateaux et le placement, même si derrière un contôle est fait en back.
- Le contrôleur de joueur permet la connexion via JWT et la création de compte. Rien de spécial dessus.
- Le contrôleur de stats, semble très petit néanmoins à mon sens, de la façon où je l'ai implémenté, il est complet. En effet, le front fait le traitement.
