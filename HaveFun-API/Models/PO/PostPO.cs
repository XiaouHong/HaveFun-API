using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HaveFun_API.Models.PO;

/// <summary>
/// 文章
/// </summary>
public class PostPO
{
    /// <summary>
    /// 編號
    /// </summary>
    [Key]
    public int ID { get; set; } = 0;

    /// <summary>
    /// 發文者
    /// </summary>
    public int MemberID { get; set; } = 0;

    /// <summary>
    /// 文章標題
    /// </summary>
    public string Title { get; set; } = "";

    /// <summary>
    /// 文章內容
    /// </summary>
    public string Content { get; set; } = "";

    /// <summary>
    /// 文章類別
    /// </summary>
    public int Type { get; set; } = 0;

    public DateTime CreateTime { get; set; } = DateTime.Now;

    public string CreateUser { get; set; } = "";

    public int CurrentVersionId { get; set; } = 0;
}
