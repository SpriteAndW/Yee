namespace Assets.Plugins.System
{
    #region Enum

    public enum InputsType //输入类型
    {
        Horizontal = 1 << 1, //水平
        Vertical = 1 << 2, //竖直
        MouseLeftButtonDown = 1 << 3, //鼠标左键按下
        MouseRightButtonDown = 1 << 4, //鼠标右键按下
        MouseMiddleButtonDown = 1 << 5, //鼠标中键按下
        MouseLeftButtonUp = 1 << 6, //鼠标左键抬起
        MouseRightButtonUp = 1 << 7, //鼠标右键抬起
        MouseMiddleButtonUp = 1 << 8, //鼠标中键抬起
        MouseLeftButton = 1 << 9, //鼠标左键
        MouseRightButton = 1 << 10, //鼠标右键
        MouseMiddleButton = 1 << 11, //鼠标中键
        MouseScrollWheel = 1 << 12, //鼠标滚轮
        KeyCodeQ = 1 << 13,
        KeyCodeW = 1 << 14,
        KeyCodeE = 1 << 15,
        KeyCodeR = 1 << 16,
        KeyCodeA = 1 << 17,
        KeyCodeD = 1 << 18
    }

    public enum UnitTag //标签
    {
        Untagged = 1 << 1,
        Respawn = 1 << 2,
        Finish = 1 << 3,
        EditorOnly = 1 << 4,
        MainCamera = 1 << 5,
        Player = 1 << 6,
        GameController = 1 << 7,
        Enemy = 1 << 8
    }

    public enum GroundType //地板类型
    {
        Default = 1 << 1, //默认
        Stone = 1 << 2 //石头
    }

    public enum ObjectType //Object类型
    {
        Default = 1 << 1, //默认
        Item = 1 << 2, //物品
        Skill = 1 << 3, //技能
        Effect = 1 << 4, //特效
        UI = 1 << 5, //UI
        Fruits = 1 << 6 //水果(幻珠)
    }

    public enum SkillLockEventType//调用判断技能是否锁定函数时的事件类型
    {
        GetItem = 1 << 1,//获得物品
        RemoveItem = 1 << 2,//失去物品
        UseItem = 1 << 3,//使用物品
        GetState = 1 << 4,//获得状态
        RemoveState = 1 << 5//失去状态
    }

    public enum SkillType //技能类型
    {
        Default = 1 << 1, //默认
        Thunder = 1 << 2, //雷法
        Hallucination = 1 << 3 //幻术
    }

    public enum SkillIndictorType //技能指示器类型
    {
        Default = 1 << 1, //默认无
        Direction = 1 << 2, //长条形
        Cone = 1 << 3, //扇形
        Point = 1 << 4, //鼠标生成一小片范围
        Range = 1 << 5 //自身周围的范围
    }

    public enum SkillInstateType
    {
        WithParent = 1 << 1,
        WithoutParent = 1 << 2,
        InMousePos = 1 << 3
    }

    public enum SymbolType //符箓类型
    {
        Default = 1 << 1, //默认
        RuneWater = 1 << 2, //画符水
        Burning = 1 << 3, //燃烧
        Swallow = 1 << 4 //吞服
    }

    public enum ItemType //物品类型
    {
        Default = 1 << 1, //默认
        Symbol = 1 << 2, //符箓
        Combustible = 1 << 3, //可燃物
        Mechanism = 1 << 4, //机关
        Plant = 1 << 5 //植物
    }

    public enum PortalType //传送门类型
    {
        Default = 1 << 1, //默认
        AToB = 1 << 2 //A=>B
    }

    public enum TrapType //陷阱类型
    {
        Default = 1 << 1, //默认
        Burning = 1 << 2, //燃烧
        Spear = 1 << 3, //戳刺
        CodeDoor = 1 << 4 //类密码门
    }

    public enum SingletonPriority //单例优先级
    {
        Late = 1 << 1, //新的优先
        Last = 1 << 2 //旧的优先
    }

    public enum RoleType //角色类型
    {
        Default = 1 << 1, //默认
        Player = 1 << 2, //玩家
        Enemy = 1 << 3, //敌人
        Neutral = 1 << 4, //中立
        Friendly = 1 << 5 //友好
    }

    public enum ColliderType
    {
        Default = 1<<1,//默认
        Weapon_DaoQi = 1 <<2,
        Other_DaoQi = 1<< 3,
        FuLu =1 << 4
    }

    public enum MoveState //移动状态
    {
        Default = 1 << 1, //默认
        Idle = 1 << 2, //站立
        Walk = 1 << 3, //走路
        Jump = 1 << 4, //跳跃
        Crouch = 1 << 5 //蹲下
    }

    public enum FightState //战斗状态
    {
        Default = 1 << 1, //默认
        Idle = 1 << 2, //站立
        Attack = 1 << 3, //攻击
        Damage = 1 << 4, //受伤
        Stuck = 1 << 5, //困住
        LayDown = 1 << 6 //躺下
    }

    public enum ExistState //存在状态
    {
        Default = 1 << 1, //默认
        Alive = 1 << 2, //存活
        Invincible = 1 << 3, //无敌
        Dead = 1 << 4 //死亡
    }

    public enum AnimState //动画状态
    {
        Idle = 1 << 1,
        Walk = 1 << 2,
        Die = 1 << 3
    }

    public enum UIType //UI类型
    {
        Default = 1 << 1, //默认
        Button = 1 << 2, //按钮
        FuLu = 1 << 3, //符箓
        DaoQi = 1 << 4, //道器
        HuaFaShui = 1 << 5,
        RanShao = 1 << 6,
        NeiFu = 1 << 7,
        Equip = 1 << 8,
        Out = 1 << 9,
        Skill = 1 << 10,
        BookOneCatalogue = 1 << 11,
        BookLabel = 1 << 12,
        BlankFuLu = 1 <<13
    }

    public enum HoldPropType //手中道具类型
    {
        Default = 1 << 1, //默认
        Weapon = 1 << 2, //武器
        Drop = 1 << 3, //投射物
        Multiplier = 1 << 4 //法器
    }

    public enum PropType //道具类型
    {
        Default = 1 << 1, //默认
        Weapon = 1 << 2, //武器
        Drop = 1 << 3, //投射物
        Multiplier = 1 << 4 //法器
    }

    public enum DrainType //道具使用（消耗）类型
    {
        Default = 1 << 1, //默认
        OneTime = 1 << 2, //一次性
        Normal = 1 << 3 //多次
    }

    public enum AIStimulator //AI刺激源
    {
        Default = 1 << 1, //默认
        Hear = 1 << 2, //听觉
        Sight = 1 << 3, //视觉
        Pain = 1 << 4 //痛觉
    }

    public enum AIMoveType //AI个体行动类型
    {
        Default = 1 << 1, //默认
        Idle = 1 << 2, //静止
        Roaming = 1 << 3, //漫游
        Chasing = 1 << 4, //追逐
        Death = 1 << 5, // 死亡
        Puzzle = 1 <<6
    }

    public enum AIBuffState
    {
        Default = 1 << 1, //默认
        Burn = 1 << 2, //燃烧
        Dizz = 1 << 3, //眩晕
        Puzzle = 1 << 4, //迷惑(可对话)
    }

    public enum AIManagerMoveType //AI群体行动类型
    {
        Default = 1 << 1, //默认
        Idle = 1 << 2, //静止
        Roaming = 1 << 3, //漫游
        Chasing = 1 << 4, //追逐
        Back = 1 << 5 //返回初始位置
    }


    public enum OtherThingType
    {
        CanBurn,
        Havetunnel,
        Nature
    }

    #region MiniGame_Watermelon

    public enum WatermelonGameState
    {
        Ready = 1 << 0,
        StanBy = 1 << 1,
        InProgress = 1 << 2,
        GameOver = 1 << 3,
        CalculateScore = 1 << 4
    }

    public enum FruitType
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
    }

    public enum FruitState
    {
        Ready = 1,
        StanBy = 2,
        Dropping = 3,
        Collision = 4
    }

    #endregion

    #endregion
}