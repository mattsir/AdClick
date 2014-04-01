<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="AdClick.hroot.detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <style type="text/css">
        body {
            font-size: 12px;
            line-height: 120%;
        }
        .div100 {
            width: 100%;
            float: left;
             height: 30px;
            line-height: 30px;
            border-bottom:#e1e1e1 1px solid;
        }
        .div {
            float: left;
            height: 30px;
            line-height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="div100" style=" vertical-align:top;">
    <div class="div100">点击详情列表
        </div>
            <div class="div100">
                <div class="div" style="width:100px;">IP</div>
                <div class="div" style="width:120px;">
                时间
                    </div>
                    <div class="div" style="width:100px;">
                    地区
                    </div>
                     <div class="div" style="width:100px;">
                    省份
                    </div>
                     <div class="div" style="width:100px;">
                    城市 
                    </div>
                    <div class="div" style="width:100px;">
                    操作系统 
                    </div>
                    <div class="div" style="width:150px;">
                    浏览器
                    </div>
                    </div>
            <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div class="div100">
                <div class="div" style="width:100px;"><%# Eval("ip") %></div>
                <div class="div" style="width:120px;">
                <%# Eval("addtime") %>
                    </div>
                    <div class="div" style="width:100px;">
                    <%# Eval("area") %>  
                    </div>
                     <div class="div" style="width:100px;">
                    <%# Eval("region") %>  
                    </div>
                     <div class="div" style="width:100px;">
                    <%# Eval("city") %>  
                    </div>
                    <div class="div" style="width:100px;">
                    <%# Eval("system") %>  
                    </div>
                    <div class="div" style="width:150px;">
                    <%# Eval("browser") %>  
                    </div>
                    </div>
            </ItemTemplate>
        </asp:Repeater>
            </div>

    </div>
    </form>
</body>
</html>
