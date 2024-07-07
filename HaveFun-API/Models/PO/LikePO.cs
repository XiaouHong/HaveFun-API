using HaveFun_API.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HaveFun_API.Models.PO;

/// <summary>
/// 按讚
/// </summary>
public class LikePO
{
    /// <summary>
    /// 編號
    /// </summary>
    [Key]
    public int ID { get; set; } = 0;

    /// <summary>
    /// 按讚類別
    /// </summary>
    public LikeType Type { get; set; } = LikeType.Unknow;

    /// <summary>
    /// 目標編號
    /// </summary>
    public int TargetID { get; set; } = 0;

    /// <summary>
    /// 成員編號
    /// </summary>
    public int MemberID { get; set; } = 0;

    /// <summary>
    /// 按讚日期
    /// </summary>
    public DateTime LikedDate { get; set; } = DateTime.Now;
}
