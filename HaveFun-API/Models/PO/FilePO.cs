using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HaveFun_API.Models.PO;

/// <summary>
/// 檔案
/// </summary>
public class FilePO
{
    /// <summary>
    /// 編號
    /// </summary>
    [Key]
    public int ID { get; set; } = 0;

    /// <summary>
    /// 目標類別
    /// </summary>
    public int Type { get; set; } = 0;

    /// <summary>
    /// 目標編號
    /// </summary>
    public int TargetID { get; set; } = 0;

    /// <summary>
    /// 網址
    /// </summary>
    public string Src { get; set; } = "";

    /// <summary>
    /// 開始時間
    /// </summary>
    public DateTime CreateTime { get; set; } = DateTime.Now;
}
