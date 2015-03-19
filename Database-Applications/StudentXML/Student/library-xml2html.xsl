<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <body>
        <h1>Students</h1>
        <table bgcolor="#E0E0E0" cellspacing="1">
          <tr bgcolor="#EEEEEE">
            <td>
              <b>Name</b>
            </td>
            <td>
              <b>Gender</b>
            </td>
            <td>
              <b>Bith-date</b>
            </td>
            <td>
              <b>phone-number</b>
            </td>
          </tr>
          <xsl:for-each select="/students/student">
            <tr bgcolor="white">
              <td>
                <xsl:value-of select="name"/>
              </td>
              <td>
                <xsl:value-of select="gender"/>
              </td>
              <td>
                <xsl:value-of select="birth-date"/>
              </td>
              <td>
                <xsl:value-of select="phone-number"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
