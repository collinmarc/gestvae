BUILD 20250313
	Prise en compte des L1 valides

BUILD 20250310
	Suppression des diplome en double
	Trt des L2 dans DC
	extraction sur CAFDESV2
	Irrecevable

BUILD 20250225
	Maintenance Fevrier 2025 : Gestion des L1

BUILD 20241202
	#1717 : Maintenance 02/12
BUILD 20241012
	Migration : Suppression des CREATE OR ALTER

BUILD 20241014
	CAFDESV2

BUILD XXXXXXXX
	0001569: Ajout d'une extraction pour 'moncompteFormation'


BUILD XXXXXXXX
	0001279: La fenêtre détail des diplomes ne met pas à jour les données
	0001278: Initialisation du statut des Domaines de Compétences
BUILD 20200526
0001235: Saisie des dates : < 01/01/2080
0001236: L2 : Validation partielle : Click sur Défavorable

Build 20200515
0001225: Ajout du libellé des piéces jointes dans l'extraction RQ_L2_DOC
0001224: Dissocier les cases à cocher 'enregistré' et Payé entre le L1 et le L2


Build : 20200428
0001213: L2 : Liste des Collèges vide dans la liste des jurys
Build : 20200428
0001213: L2 : Liste des Collèges vide dans la liste des jurys

Build : 20200310
0000985: Gestion des membres du jury
0000895: Recherche : Date de validation L1 et L2
0001039: Ajout du Post-Formation
0001022: L2 : Diplome CAERUIS ET DEIS
0001042: Ajout de commentaires sur le dossier d'un candidat

Build : 20200201
0001139: date de création du L2 > date de validité du L1

Build : 20200201
0001162: L1 : Suppression , date de jury de recours et Commentaires
0001163: L1 : Type de recours (Gracieux ou contentieux)
0001155: MAJ DES Extractions (VRAI/FAUX=> OU/NON , SEXE => H/F)
0001157: L2 : Heure de convoc et Heure de jury ne pas afficher les secondes
0001161: Les contrats et convnetion n'apparaissent pas dans les Extraction L2
0001020: L2 : Réorganisation des cols dans extraction L2
0001028: Fusion des dates du L1 + Réorganisation de l'extraction RQ_L1_DOC
0001156: L1 : Non Reçu par defaut
0001158: L1-L2 : CNI, attestation
0001159: L1, L2 : Ajout de isEnregistre, IsPayE
0001154: Ajout d'un Flag 'Trt Spécial' sur les L2
0000987: Diplome : Ajout d'un Numéro EURODIR
0001047: Taille de fenêtres de L1 et de L2
0000999: Fiche Candidat : Ajout Type de Demande
0000922: Application en singleton
0001149: Date de Limite de recours change après cocher la case recours
0001045: L2 : Validation Totale : MAJ des états de DC Livrets
0001153: Validité du L1 : à Vie si un DC est Validé sur un L2
0001103: Chgmt date de recevabilité du L2 
0001112: Message de sauvegarde en faisant une recherche
0001040: L2: Création du L2 => les DC sont automatiquement déclarés à AValider
0001138: Création d'une ligne Vide dans les jurys, ligne impossible à supprimer
0001166: Ajout d'une fonction d'export de base de données


Build :V20191014
0001044: La Recherche sur Nom ne fonctionne pas
0001035: L2 : Extraction Revoir les formats des Dates et Heures

Build :V20191010
000938 : Le param NumeroDeCandidat n'est pas pris en compte automatiquement
0001038: frmDiplome : Liste des modes d'obtention vides
0001030: L2 : La suppression des Membres du jurys ne fonctionne pas
0001007: changer le nom dans la zone de recherche déclenche le Sauvegarder


Build :V20190901
0001014: Ajout d'un commentaire Libre si 'autres' dans les Catégories de pièces jointes
0001015: L1 & L2 : edition des Libellés de PJ : WrapMode
0001016: L2 : La date de validité ne s'affiche pas parès un second Passage pour le L2
0001017: Extract L1 : date de création , Suppr cols inutiles
0001021: DOC9-10 : Status des DC par candidats


Build : V20190620
0000989: Les nouveaux Candidats n'apparaissent pas sur les extractions
0000996: L1: Date de recevalivité doit être à NULL par defaut.
0000998: Extraction L1 : Modif DATE JURY => Date de recevabilité, pas de DateLimiteReceptionEHESP
0001003: Ajout d'un L2 second passage : Garder le Numro de Livret
0001002: L2 : Date de jury entre le et le : intervalle de date
0001004: L2 : date de Validité et date d'envoi
0001009: L1 & L2 : mettre les cols de la fiche candidats en premier dans l'extraction

Build : V20190527
#970 : Connexion à la base de données
Icone dans la barre des taches
0000977: Recherche Candidat : Mettre en surbrillance le premier Candidat
0000971: FrmL1 et frmL2 : Onglet Jury
0000974: frmL1 : Cloturer et Creer L2
0000973: frmCandidtat : Liste des Livrets : Date de validité
0000975: frmCandidat : Ajout de L2
0000976: frmL2 : Validation Partielle (Motif G et Motif D)
0000984: frmL2 : Date Limite
0000980: FrmCandidat
0000981: frmL1
frmL1 : Date de jury : Refresh date Lmite et date limite de recours
0000983: Etat Accepté-Refusé => Favorable,Défavorable
0000978: Mettre à null les dates inutiles
0000992: La date de validité d'un L2 ne change pas
0000989: Les nouveaux Candidats n'apparaissent pas sur les extractions
0000990: Case contrat , convention, non recue disparait
0000979: Date de création sur la fiche Candidat
0000991: Ajout des pièces jointes dans extractions L1 et L2
0000994: Dbl-Click sur candidat = Lock
0000993: Regrouper les Cols Etat Civil dans RQ_L1_DOC et RQ_L2_DOC

Build : 20190515
#947 : Initialisation de la base pour les versions > 201904029
#948: Fiche candidat
#950: L1 Demandé :Pas de date de validité , Pas de Type de Livret
#951: L1 Envoyé :Pas de date de validité , Pas de Type de Livret
#952: 	0000952: frm Livret 1 : Recu incomplet
#953: frmLivret1 : reçu complet
#954:frmLivret1 : Onglet recevabilité
#955: Fiche candidat : ajout d'un bouton supprimer Livret
#957: frm Livret2 : Recçu incomplet
#958: frm Livret2 : Reçu complet
#959: frmLivret2 : Recu complet : Onglet jury
0000960: frm Livret2 : Recçu incomplet , validation partielle
0000961: frm Livret2 : Recçu incomplet , validation partielle
0000965: frm Livret2 :envoyé : numéro de passage
0000966: frm Livret2 : Reçu incomplet
0000929: Ajout d'un raccourci pour effectuer la Sauvegarde
Reponses1405

Build : 20190429
#923 : FrmCandidat Désactivé si le candiat est null
#937 : Ajout d'un numéro de version
#925: Quitter sans sauvegarder
#933: FrmCandidat : Sexe non actif, Champs décalé
#939: Mise a jours des Migrations automatique
#927: Génération du Numero du Livret
#931: L2 : Date de Validité
#928: L1: Date de validité
#934: Ajout d'un L2 sur un L2 en validation Partielle
#918: Suppression d'un L1 avec PJ et jury
#900: L1 (Jury) : Calcul de date Limite de Recours
#932: L1 : Motif du recours sur L1
#940: L1-L2 :Les dates de pièces manquantes sont activées uniquement si Dossier Recu
#942: Les pièces jointes ne sont pas dans la base de données
#943: La Gestion des diplomes ne fonctionne pas
#941: L2 : La Date Limite de réception = Date de validité du L1.
#944: Alerte sur les candidats verrouillés en recherche
#945: Ajout des données
#946: Ajout des département dans les membres de jurys

Build : 20190411 