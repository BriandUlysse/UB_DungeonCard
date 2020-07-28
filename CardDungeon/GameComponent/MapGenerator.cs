using CardDungeon.GameComponent.Entities;
using CardDungeon.GameComponent.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDungeon.GameComponent
{
    public static class MapGenerator
    {
        private static Random rnd = new Random();

        public static Entity[,] generateMapCard(int width, int height, int level)
        {
            Entity[,] entities = new Entity[width, height];

            int ratio = width * height;

            int nbLevelCalcul = level - 1;

            int nbEnemy = rnd.Next((int) (ratio*0.1), (int)(ratio*0.3));
            int nbWeapon = rnd.Next((int)(ratio * 0.1), (int)(ratio * 0.20));
            int nbHeal = rnd.Next((int)(ratio * 0.08), (int)(ratio * 0.12));
            int nbArmor = rnd.Next((int)(ratio * 0.05), (int)(ratio * 0.1));
            bool ladderPlaced = false;

            while (nbArmor>0&&nbWeapon>0&&nbEnemy>0&&nbHeal>0)
            {
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (entities[i, j]==null)
                        {
                            Entity res = null;
                            int value = rnd.Next(20);
                            if (value < 4)
                            {
                                if (nbEnemy > 0)
                                {
                                    res = randomEnemy(nbLevelCalcul);
                                    nbEnemy--;
                                }
                            }
                            else if (value < 7)
                            {
                                if (nbWeapon > 0)
                                {
                                    res = randomWeapon(nbLevelCalcul);
                                    nbWeapon--;
                                }
                            }
                            else if (value < 8)
                            {
                                if (nbHeal > 0)
                                {
                                    res = randomPotion(nbLevelCalcul);
                                    nbHeal--;
                                }
                            }
                            else if (value < 10)
                            {
                                if (nbArmor > 0)
                                {
                                    res = randomArmor(nbLevelCalcul);
                                    nbArmor--;
                                }
                            }

                            entities[i, j] = res;
                        }
                    }   
                }
            }

            while (!ladderPlaced)
            {
                int x = rnd.Next(width);
                int y = rnd.Next(height);

                if (entities[x,y] == null)
                {
                    entities[x, y] = new Ladder();
                    ladderPlaced = true;
                }
            }
            
            return entities;
        }

        private static Enemy randomEnemy(int level)
        {
            Enemy res = null;
            int value = rnd.Next((level * 4), 10 + (level * 4));
            if (value<10)
            {
                res = randomEnemyTier1();
            }
            else if (value<20)
            {
                res = randomEnemyTier2();
            }
            else if(value<30)
            {
                res = randomEnemyTier3();
            }
            else
            {
                res = randomEnemyTier4();
            }
            return res;
        }

        #region enemyByTier

        private static Enemy randomEnemyTier1()
        {
            Enemy res;
            int value = rnd.Next(10);

            if (value<4)
            {
                res = new Enemy(EnemyType.SMALL_CRIER);
            }
            else if (value < 7)
            {
                res = new Enemy(EnemyType.SMALL_ZOMBIE);
            }
            else
            {
                res = new Enemy(EnemyType.SMALL_DEMON);
            }

            return res;
        }

        private static Enemy randomEnemyTier2()
        {
            Enemy res;
            int value = rnd.Next(10);

            if (value < 3)
            {
                res = new Enemy(EnemyType.SMALL_ZOMBIE);
            }
            else if (value < 6)
            {
                res = new Enemy(EnemyType.SMALL_DEMON);
            }
            else
            {
                res = new Enemy(EnemyType.SKELETON);
            }

            return res;
        }

        private static Enemy randomEnemyTier3()
        {
            Enemy res;
            int value = rnd.Next(10);

            if (value < 4)
            {
                res = new Enemy(EnemyType.CRIER);
            }
            else if (value < 7)
            {
                res = new Enemy(EnemyType.ZOMBIE);
            }
            else
            {
                res = new Enemy(EnemyType.DEMON);
            }

            return res;
        }

        private static Enemy randomEnemyTier4()
        {
            Enemy res;
            int value = rnd.Next(10);

            if (value < 2)
            {
                res = new Enemy(EnemyType.CRIER);
            }
            else if (value < 4)
            {
                res = new Enemy(EnemyType.ZOMBIE);
            }
            else if(value < 6)
            {
                res = new Enemy(EnemyType.DEMON);
            }
            else if (value < 8)
            {
                res = new Enemy(EnemyType.GARGABAGE);
            }
            else
            {
                res = new Enemy(EnemyType.MASKED_ZOMBIE);
            }

            return res;
        }

        #endregion

        private static Armor randomArmor(int level)
        {
            Armor res = null;
            int value = rnd.Next((level * 4), 10 + (level * 4));
            if (value < 10)
            {
                res = randomArmorTier1();
            }
            else if (value < 20)
            {
                res = randomArmorTier2();
            }
            else if(value< 30)
            {
                res = randomArmorTier3();
            }
            else
            {
                res = randomArmorTier4();
            }
            return res;
        }

        #region armorByTier
        private static Armor randomArmorTier1()
        {
            return new Armor(1);
        }

        
        private static Armor randomArmorTier2()
        {
            return new Armor(2);
        }

        private static Armor randomArmorTier3()
        {
            return new Armor(3);
        }

        private static Armor randomArmorTier4()
        {
            return new Armor(4);
        }

        #endregion

        private static Weapon randomWeapon(int level)
        {
            Weapon res = null;
            int value = rnd.Next((level * 4), 10 + (level * 4));
            if (value < 10)
            {
                res = randomWeaponTier1();
            }
            else if (value < 20)
            {
                res = randomWeaponTier2();
            }
            else if (value <30)
            {
                res = randomWeaponTier3();
            }
            else
            {
                res = randomWeaponTier4();
            }
            return res;
        }

        #region weaponByTier
        private static Weapon randomWeaponTier1()
        {
            Weapon res;
            int value = rnd.Next(10);

            if (value < 4)
            {
                res = new Weapon(WeaponType.KNIFE);
            }
            else if(value <8)
            {
                res = new Weapon(WeaponType.STAFF);
            }
            else
            {
                res = new Weapon(WeaponType.SWORD);
            }

            return res;
        }

        private static Weapon randomWeaponTier2()
        {
            Weapon res;
            int value = rnd.Next(10);

            if (value < 4)
            {
                res = new Weapon(WeaponType.SWORD);
            }
            else if(value < 6)
            {
                res = new Weapon(WeaponType.RAPIER);
            }
            else
            {
                res = new Weapon(WeaponType.SPEAR);
            }

            return res;
        }

        private static Weapon randomWeaponTier3()
        {
            Weapon res;
            int value = rnd.Next(10);

            if (value < 3)
            {
                res = new Weapon(WeaponType.SPEAR);
            }
            else if(value <6)
            {
                res = new Weapon(WeaponType.SWORD);
            }
            else
            {
                res = new Weapon(WeaponType.BIG_SWORD);
            }

            return res;
        }

        private static Weapon randomWeaponTier4()
        {
            Weapon res;
            int value = rnd.Next(10);

            if (value < 5)
            {
                res = new Weapon(WeaponType.AXE);
            }
            else
            {
                res = new Weapon(WeaponType.DAGGER);
            }

            return res;
        }

        #endregion

        private static Potion randomPotion(int level)
        {
            Potion res = null;
            int value = rnd.Next((level * 4), 10 + (level * 4));
            if (value < 10)
            {
                res = randomPotionTier1();
            }
            else if (value < 20)
            {
                res = randomPotionTier2();
            }
            else if(value<30)
            {
                res = randomPotionTier3();
            }
            else
            {
                res = randomPotionTier4();
            }
            return res;
        }

        #region potionByTier

        private static Potion randomPotionTier1()
        {
            return new Potion(PotionType.APPLE);
        }


        private static Potion randomPotionTier2()
        {
            return new Potion(PotionType.SMALL_POTION);
        }

        private static Potion randomPotionTier3()
        {
            return new Potion(PotionType.CAKE);
        }

        private static Potion randomPotionTier4()
        {
            return new Potion(PotionType.BIG_POTION);
        }

        #endregion
    }
}
