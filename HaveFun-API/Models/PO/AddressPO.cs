using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HaveFun_API.Models.PO;

/// <summary>
/// 地址
/// </summary>
public class AddressPO
{
    /// <summary>
    /// 編號
    /// </summary>
    [Key]
    public int ID { get; set; } = 0;

    /// <summary>
    /// 國家
    /// </summary>
    [MaxLength(20)]
    public string Country { get; set; } = "";

    /// <summary>
    /// 城市
    /// </summary>
    [MaxLength(3)]
    public string City { get; set; } = "";

    /// <summary>
    /// 城鎮
    /// </summary>
    [MaxLength(3)]
    public string Town { get; set; } = "";

    /// <summary>
    /// 區碼
    /// </summary>
    [MaxLength(5)]
    public string Code { get; set; } = "";
}
