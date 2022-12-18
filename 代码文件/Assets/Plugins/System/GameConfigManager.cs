#region

//===================================================||
//作者：溫柔可愛柠檬草
//===================================================||

#endregion

#region

using System.Collections.Generic;
using Assets.Plugins.Script.BaseClass.Hide;
using UnityEngine;

#endregion

namespace Assets.Plugins.System
{
    /// <summary>
    ///     通用游戏配置表
    ///     此为单实例：
    ///     Data配置表
    /// </summary>
    public class GameConfigManager : HideActor<GameConfigManager> //不继承Monobehavior可以直接初始化
    {
        //对话
        private GameConfigData _itemDescriptionData;

        //对话
        private GameConfigData _talkData;

        //文本
        private TextAsset _textAsset;

        /// <summary>
        ///     构造
        /// </summary>
        public GameConfigManager()
        {
            Init();
        }

        public void Init() //初始化
        {
            //对话
            _textAsset = Resources.Load<TextAsset>("Data/Txt/TalkData");
            _talkData = new GameConfigData(_textAsset.text); //初始化字典表
            //描述
            _textAsset = Resources.Load<TextAsset>("Data/Txt/YiItemDesription");
            _itemDescriptionData = new GameConfigData(_textAsset.text);
        }

        //对话表
        public int GetTalkLines() //获得对话表长度
        {
            return _talkData.GetLines();
        }

        public Dictionary<string, string> GetTalkById(string id) //按Id获取对话表中的对话
        {
            return _talkData.GetOneById(id);
        }

        //描述表
        public int GetDescriptionLines() //获得描述表长度
        {
            return _itemDescriptionData.GetLines();
        }

        public Dictionary<string, string> GetDescriptionById(string id) //按Id获取描述表中的描述
        {
            return _itemDescriptionData.GetOneById(id);
        }
    }
}