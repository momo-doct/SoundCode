//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：2019-10-28 01:09:10
//备    注：
//===================================================
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// 服务器返回查询背包项消息
/// </summary>
public struct Backpack_SearchReturnProto : IProto
{
    public ushort ProtoCode { get { return 16005; } }
    public string ProtoEnName { get { return "Backpack_SearchReturn"; } }

    public int BackpackItemCount; //背包项数量
    public List<BackpackItem> ItemList; //背包项

    [Serializable]
    /// <summary>
    /// 背包项
    /// </summary>
    public struct BackpackItem
    {
        public int BackpackItemId; //背包项编号
        public byte GoodsType; //物品类型
        public int GoodsId; //物品基础编号
        public int GoodsServerId; //物品服务器端编号
        public int GoodsOverlayCount; //物品叠加数量
    }

    public byte[] ToArray(MMO_MemoryStream ms, bool isChild = false)
    {
        ms.SetLength(0);
        if (!isChild)
        {
            ms.WriteUShort(ProtoCode);
        }

        ms.WriteInt(BackpackItemCount);
        for (int i = 0; i < BackpackItemCount; i++)
        {
            var item = ItemList[i];
            ms.WriteInt(item.BackpackItemId);
            ms.WriteByte(item.GoodsType);
            ms.WriteInt(item.GoodsId);
            ms.WriteInt(item.GoodsServerId);
            ms.WriteInt(item.GoodsOverlayCount);
        }

        return ms.ToArray();
    }

    public static Backpack_SearchReturnProto GetProto(MMO_MemoryStream ms, byte[] buffer)
    {
        Backpack_SearchReturnProto proto = new Backpack_SearchReturnProto();
        ms.SetLength(0);
        ms.Write(buffer, 0, buffer.Length);
        ms.Position = 0;

        proto.BackpackItemCount = ms.ReadInt();
        proto.ItemList = new List<BackpackItem>();
        for (int i = 0; i < proto.BackpackItemCount; i++)
        {
            BackpackItem _Item = new BackpackItem();
            _Item.BackpackItemId = ms.ReadInt();
            _Item.GoodsType = (byte)ms.ReadByte();
            _Item.GoodsId = ms.ReadInt();
            _Item.GoodsServerId = ms.ReadInt();
            _Item.GoodsOverlayCount = ms.ReadInt();
            proto.ItemList.Add(_Item);
        }

        return proto;
    }
}