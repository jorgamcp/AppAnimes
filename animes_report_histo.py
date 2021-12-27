import datetime
import pyodbc
from fpdf import FPDF
# Some other example server values are
# server = 'localhost\sqlexpress' # for a named instance
# server = 'myserver,port' # to specify an alternate port
server = 'KAOS'
database = 'AppAnimesDB'

pdf = FPDF(orientation='L', unit='mm', format='A4')
pdf.add_page()
pdf.set_font('Arial', '', 25)
pdf.cell(w=0, h=15, txt='Histórico  Animes', border=1, ln=1, align='C', fill=0)
pdf.set_font('Arial', '', 9)


#  cnxn = pyodbc.connect('DRIVER={ODBC Driver 17 for SQL Server};SERVER=' + server+';DATABASE='+database+';UID='+username+';PWD=' + password)
cnxn = pyodbc.connect('DRIVER={ODBC Driver 17 for SQL Server};SERVER=' +server+';DATABASE='+database+';Trusted_Connection=yes;')
cursor = cnxn.cursor()
contador_linea = 0
cursor.execute("""
SELECT [Nombre Anime +  Temporada] as nombre,VistoEn,Estado,
	CONVERT(date,FechaInicio),CONVERT(date,fechaFin),AnyoVisto
from
	HistoricoConNombres_View
	order by FechaInicio desc
""")
animes = cursor.fetchall()

pdf.cell(w=177, h=5, txt='Nombre', border=1,ln=0 ,align='C', fill=0)
pdf.cell(w=20, h=5, txt='Visto En', border=1,ln=0 ,align='C', fill=0)
pdf.cell(w=20, h=5, txt='Estado', border=1,ln=0 ,align='C', fill=0)
pdf.cell(w=20, h=5, txt='Fecha Inicio', border=1,ln=0 ,align='C', fill=0)
pdf.cell(w=20, h=5, txt='Fecha Fin', border=1,ln=0 ,align='C', fill=0)
pdf.cell(w=20, h=5, txt='Anyo Visto', border=1,ln=1 ,align='C', fill=0)


for  nombre,VistoEn,Estado,FechaInicio,FechaFin,AnyoVisto in animes:
    # print(animeid, nombre)
    pdf.cell(w=177, h=5, txt=str(nombre), border=1,ln=0 ,align='C', fill=0)
    pdf.cell(w=20, h=5, txt=str(VistoEn), border=1, ln=0,align='C', fill=0)
    pdf.cell(w=20, h=5, txt=str(Estado), border=1, ln=0,align='C', fill=0)
    if FechaInicio == None and Estado =='Visto':
        pdf.cell(w=20, h=5, txt=str('Desconocida'), border=1, ln=0,align='C', fill=0)        
    else:
        pdf.cell(w=20, h=5, txt=str(FechaInicio), border=1, ln=0,align='C', fill=0)
    if FechaFin == None and Estado == 'Viendo':
        pdf.cell(w=20, h=5, txt=str('-'), border=1, ln=0,align='C', fill=0)
    else:
        pdf.cell(w=20, h=5, txt=str(FechaFin), border=1, ln=0,align='C', fill=0)

    if AnyoVisto == None:
        pdf.cell(w=20, h=5, txt=str('-'), border=1, ln=1,align='C', fill=0)
    else: 
        pdf.cell(w=20, h=5, txt=str(AnyoVisto), border=1, ln=1,align='C', fill=0)
    

    #pdf.cell(w=0, h=5, txt=str(nombre.rsplit(' ',9)[0]), border=1, ln=1,align='C', fill=0)

    

    #cadena.rsplit(' ',9)[0]
    contador_linea = contador_linea + 1
cursor.close()
cnxn.close()

pdf.output('animes_histo.pdf')
pdf.close()