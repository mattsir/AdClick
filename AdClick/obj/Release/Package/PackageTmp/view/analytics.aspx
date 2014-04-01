<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="analytics.aspx.cs" Inherits="AdClick.view.analytics" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
            #Total
            {
                font-family:Impact;
                font-size:20px;
                font-weight:bold;
                height: 30px;
            line-height: 30px;
            }
            #Product
            {
                font-family:'微软雅黑';
                font-size:20px;
                font-weight:bold;
                height: 30px;
            line-height: 30px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <div class="div100"><span id="Product" runat="server"></span> 点击分析 合计点击 <span id="Total" runat="server"></span> 次</div>
        <div class="div100" style="width:200px; vertical-align:top; margin-left:40px;">
            <div class="div" style="width:100px;">地区</div>
                <div class="div" style="width:50px;">总数</div>
            <div class="div" style="width:50px;">比重</div> 
        <asp:Repeater ID="Repeater2" runat="server">
            <ItemTemplate>
                <div class="div100">
                <div class="div" style="width:100px;"><%# Eval("tyname") %></div>
                <div class="div" style="width:50px;"><%# Eval("t") %></div>
                <div class="div" style="width:50px;"><%# Eval("per") %></div>    
                </div>

                
            </ItemTemplate>
        </asp:Repeater>
            </div>

        <div class="div100" style="width:200px; vertical-align:top; margin-left:40px;">
            <div class="div" style="width:100px;">省份</div>
                <div class="div" style="width:50px;">总数</div>
            <div class="div" style="width:50px;">比重</div> 
        <asp:Repeater ID="Repeater3" runat="server">
            <ItemTemplate>
                <div class="div100">
                <div class="div" style="width:100px;"><%# Eval("tyname") %></div>
                <div class="div" style="width:50px;"><%# Eval("t") %></div>
                    <div class="div" style="width:50px;"><%# Eval("per") %></div>  
                    </div>
            </ItemTemplate>
        </asp:Repeater>
            </div>

        <div class="div100" style="width:200px; vertical-align:top; margin-left:40px;">
            <div class="div" style="width:100px;">城市</div>
                <div class="div" style="width:50px;">总数</div>
            <div class="div" style="width:50px;">比重</div> 
        <asp:Repeater ID="Repeater4" runat="server">
            <ItemTemplate>
                <div class="div100">
                <div class="div" style="width:100px;"><%# Eval("tyname") %></div>
                <div class="div" style="width:50px;"><%# Eval("t") %></div>
                    <div class="div" style="width:50px;"><%# Eval("per") %></div>  
                    </div>
            </ItemTemplate>
        </asp:Repeater>
            </div>
    

        <div class="div100" style="width:200px; vertical-align:top; margin-left:40px;">
            <div class="div" style="width:100px;">操作系统</div>
                <div class="div" style="width:50px;">总数</div>
            <div class="div" style="width:50px;">比重</div> 
        <asp:Repeater ID="SysRpt" runat="server">
            <ItemTemplate>
                <div class="div100">
                <div class="div" style="width:100px;"><%# Eval("tyname") %></div>
                <div class="div" style="width:50px;"><%# Eval("t") %></div>
                <div class="div" style="width:50px;"><%# Eval("per") %></div>    
                </div>

                
            </ItemTemplate>
        </asp:Repeater>
            </div>

        <div class="div100" style="width:200px; vertical-align:top; margin-left:40px;">
            <div class="div" style="width:100px;">浏览器</div>
                <div class="div" style="width:50px;">总数</div>
            <div class="div" style="width:50px;">比重</div> 
        <asp:Repeater ID="BroRpt" runat="server">
            <ItemTemplate>
                <div class="div100">
                <div class="div" style="width:100px;"><%# Eval("tyname") %></div>
                <div class="div" style="width:50px;"><%# Eval("t") %></div>
                    <div class="div" style="width:50px;"><%# Eval("per") %></div>  
                    </div>
            </ItemTemplate>
        </asp:Repeater>
            </div>

        </div>
    </form>
</body>
</html>