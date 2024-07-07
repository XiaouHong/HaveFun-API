using HaveFun_API.Enum;
using System.ComponentModel.DataAnnotations;

namespace HaveFun_API.Models.PO;

/// <summary>
/// 交友
/// </summary>
public class MemberShipPO
{
    /// <summary>
    /// 編號
    /// </summary>
    [Key]
    public int ID { get; set; } = 0;

    /// <summary>
    /// 成員編號
    /// </summary>
    public int MemberID { get; set; } = 0;

    /// <summary>
    /// 對象編號
    /// </summary>
    public int FriendID { get; set; } = 0;

    /// <summary>
    /// 關係類別
    /// </summary>
    public ShipType Type { get; set; } = ShipType.Unknow;
}
