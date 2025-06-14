
# 🧠 NewsInsight: 智能新闻分析平台 powered by MCP Protocol

> 🚀 A modular, intelligent news analysis system that bridges AI-driven tools and native C++ algorithms using the Model Context Protocol (MCP), .NET Core, and Blazor.

> **MCP.NewsInsight** 是一个基于 .NET 技术栈构建的智能新闻系统，利用 MCP（模型上下文协议）实现大模型与结构化数据的集成。项目包含 Blazor 前端、ASP.NET Core 平台代码、C++/CLI 封装的原生算法模块，以及 MCP Server，支持新闻搜索、摘要、推荐等功能。数据源使用 PENS 新闻数据集存储于 MySQL 中，是一个集前沿协议、智能交互、跨语言集成于一体的全栈教学实践项目。





## 📌 项目简介

**NewsInsight** 是一个基于 MCP 协议构建的智能新闻分析平台，旨在提供结构化的新闻处理服务，如摘要生成、关键词提取与搜索。项目使用 C++ 实现高性能算法，通过 `.NET 8` 后端封装并注册为 MCP Tool，可供大模型调用。用户可通过 Blazor 前端查看分析结果，实现完整闭环。


## 🏗️ 项目架构

```

MCP.NewsInsight.sln
├── NewsInsight.WebUI/               ← Blazor WebAssembly 前端
├── NewsInsight.Platform/           ← ASP.NET Core 后端 + MCP Server
│   ├── Controllers/NewsController.cs
│   ├── McpTools/NewsTools.cs       ← MCP Tool 注册点
│   ├── Services/NewsSummarizer.cs  ← DllImport 封装
├── NewsInsight.Shared/             ← 数据模型 (News.cs)
├── NewsInsight.Algorithms/         ← 原生 C++ DLL 摘要算法

```


## ⚙️ 技术栈

| 层级 | 技术 | 说明 |
|------|------|------|
| 前端 | **Blazor WebAssembly (.NET 8)** | 构建交互式 UI |
| 后端 | **ASP.NET Core Web API** | 数据接口、MCP Server 注册 Tool |
| 数据库 | **MySQL + EF Core** | 新闻数据持久化与访问 |
| 原生算法 | **C++ DLL (`NewsInsightAlgorithms.dll`)** | 实现摘要生成算法 |
| 跨语言调用 | **DllImport (`P/Invoke`)** | .NET 调用 C++ 原生函数 |
| 协议标准 | **ModelContextProtocol SDK** | 注册 MCP Tool，供 LLM 使用 |
| 部署方式 | **IIS + Kestrel** | 部署到 Windows 服务器环境 |

## 🔧 核心功能模块

| 功能 | 描述 |
|------|------|
| ✅ 新闻加载 | 从 MySQL 加载新闻列表与内容 |
| ✅ 摘要生成 | 调用原生 DLL 算法生成新闻摘要 |
| ✅ MCP 工具注册 | `summarize_news`, `extract_keywords`, `categorize_news` 等 |
| ✅ Tool 可被 API 或未来 LLM 调用 | 支持封装与标准输入交互 |
| ✅ 关键词提取 | 模拟关键词识别逻辑 |
| ✅ 关键词搜索 | 数据库全文搜索并返回标题匹配项 |


## 📂 MCP Tool 示例

```json
{
  "tool": "summarize_news",
  "parameters": { "newsId": "N10001" },
  "description": "对指定新闻生成摘要",
  "response": "这是新闻 N10001 的摘要..."
}
````

## 🚀 快速运行方式

1. 克隆仓库 & 恢复依赖
2. 配置好 MySQL 连接字符串（`appsettings.json`）
3. 编译以下项目：

   * `NewsInsight.Algorithms`（输出 DLL）
   * `NewsInsight.Platform`（自动复制 DLL）
4. 运行后端（可通过 Swagger 测试接口）
5. IIS 部署说明：

   * 使用 Kestrel 托管 ASP.NET Core 后端
   * 绑定端口 & 配置应用池为 No Managed Code
   * 前端 Blazor 可部署为静态站点


## 📈 接口示例

| 路径                                | 功能          |
| --------------------------------- | ----------- |
| `GET /api/news`                   | 获取新闻列表      |
| `GET /api/news/{id}`              | 获取新闻详情      |
| `GET /api/news/summarize/{id}`    | 调用 DLL 摘要算法 |
| `GET /api/news/keywords/{id}`     | 模拟关键词提取     |
| `GET /api/news/search?keyword=xx` | 模糊匹配新闻标题    |


## ✅ 当前已实现

* ✅ 使用 EF Core + MySQL 实现新闻数据管理
* ✅ 编写原生 C++ 摘要算法并封装为 DLL
* ✅ 使用 DllImport 实现跨语言调用
* ✅ 搭建 ASP.NET Core 后端并实现 REST API
* ✅ 注册 MCP Tool：`summarize_news`、`extract_keywords` 等
* ✅ 后端通过 Swagger 接口测试摘要功能

---

## 🔄 拟完成部分

* [ ] 前端页面整合新闻详情与摘要显示
* [ ] Blazor 中点击按钮生成摘要
* [ ] MCP Tool 接入 Claude/GPT 接口做联调测试（可选）
* [ ] 关键词提取与分类改为调用真实算法（非模拟）
* [ ] 项目整体部署到 IIS + MySQL 服务端环境


## ✨ 致谢

* [ModelContextProtocol C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
* .NET & Blazor 团队
* MCP 教学团队 & 本科项目指导


> 💬 如需更多部署帮助、代码说明或前端构建指导，请在 Issue 区提问或[联系开发者](2250694@tognji.edu.cn)。

