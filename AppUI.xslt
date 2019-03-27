<?xml version="1.0"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:frmwrk="Corel Framework Data">
  <xsl:output method="xml" encoding="UTF-8" indent="yes"/>


  <frmwrk:uiconfig>

    <frmwrk:applicationInfo userConfiguration="true" />
  </frmwrk:uiconfig>


  <xsl:template match="node()|@*">
    <xsl:copy>
      <xsl:apply-templates select="node()|@*"/>
    </xsl:copy>
  </xsl:template>

  <xsl:template match="uiConfig/items">
    <xsl:copy>
      <xsl:apply-templates select="node()|@*"/>

      <itemData guid="2863719e-c386-43be-aceb-058d7568422f"
                type="wpfhost"
                hostedType="addons\facaCaixaAuto\facaCaixaAuto.dll,Bonus630.vsta.FacaCaixaAuto.FacaCaixaAutoUI"
                enable="*Bind(DataSource=AppDS;Path=DocumentAvailable)"
                />

    </xsl:copy>
  </xsl:template>

  <xsl:template match="uiConfig/commandBars">
    <xsl:copy>
      <xsl:apply-templates select="node()|@*"/>

      <commandBarData guid="f3218995-ed44-4643-b433-c24536fe9a8d"
                      nonLocalizableName="Gerador de Corte e Vinco"
                      userCaption="Gerador de Corte e Vinco"
                      locked="true"
                      type="toolbar">
        <toolbar>
          <item  guidRef="2863719e-c386-43be-aceb-058d7568422f" dock="top"/>
        </toolbar>
      </commandBarData>
    </xsl:copy>
  </xsl:template>
  
    <xsl:template match="@*|node()">
      <xsl:copy>
        <xsl:apply-templates select="@*|node()"/>
      </xsl:copy>
    </xsl:template>
    <xsl:template match="uiConfig/containers/container[@guid='bee85f91-3ad9-dc8d-48b5-d2a87c8b2109']/container[@guid='Framework_MainFrame-layout']/dockHost[@guid='894bf987-2ec1-8f83-41d8-68f6797d0db4']/toolbar[@guidRef='c2b44f69-6dec-444e-a37e-5dbf7ff43dae']">
      <xsl:copy-of select="."/>

      <toolbar guidRef="f3218995-ed44-4643-b433-c24536fe9a8d" dock="top" />

    </xsl:template>
  
</xsl:stylesheet>
