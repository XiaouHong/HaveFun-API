using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HaveFun_API.Models.PO;

/// <summary>
/// 權限系統
/// </summary>
public class AuthoritySystemPO
{
    /// <summary>
    /// 編號
    /// </summary>
    [Key]
    public int ID { get; set; } = 0;

    /// <summary>
    /// 系統名稱
    /// </summary>
    [MaxLength(30)]
    public string Name { get; set; } = "";

    /// <summary>
    /// 系統英文名稱
    /// </summary>
    [MaxLength(30)]
    public string EnglishName { get; set; } = "";
}
