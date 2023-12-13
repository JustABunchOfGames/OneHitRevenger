namespace LevelScripts
{
    [System.Serializable]
    public class LevelSpawner
    {
        public int world;
        public int level;
        public PlayerSpawnScriptable playerSpawner;
        public WeaponSpawnScriptable weaponSpawner;
        public EnemySpawnScriptable enemySpawner;
        public TerrainSpawnScriptable terrainSpawner;
        public SpecialLevelSpawnScriptable specialLevelSpawner;

        public LevelSpawner(int world, int level, 
            PlayerSpawnScriptable playerSpawner, 
            WeaponSpawnScriptable weaponSpawner, 
            EnemySpawnScriptable enemySpawner,
            TerrainSpawnScriptable terrainSpawner,
            SpecialLevelSpawnScriptable specialLevelSpawner)
        {
            this.world = world;
            this.level = level;
            this.playerSpawner = playerSpawner;
            this.weaponSpawner = weaponSpawner;
            this.enemySpawner = enemySpawner;
            this.terrainSpawner = terrainSpawner;
            this.specialLevelSpawner = specialLevelSpawner;
        }
    }
}