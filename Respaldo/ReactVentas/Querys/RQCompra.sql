USE [LAVALIN]
GO
/****** Object:  StoredProcedure [dbo].[PA_HD_WEB_RQ_Consulta_Cabecera]    Script Date: 21/11/2022 8:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[PA_HD_WEB_RQ_Consulta_Cabecera]
@p_CodCia as Char(2), @p_CodSuc as Char(2), @p_NumRQ as Char(10)


AS
SET NOCOUNT ON
Select 
a.rco_numrco as Rco_Numero,
a.rco_fecreg as Rco_Fec_Registro, a.rco_fecsug as Rco_Fec_Sugerida,
(case a.rco_indest when '1' then 'Vigente' when '0' then 'Cancelado' else 'No Definido' end) as Rco_Estado,
a.ung_codung as Rco_U_Negocio_ID, b.ung_deslar as U_Negocio,
a.cco_codcco as Rco_Centro_Costo_ID, c.cco_deslar as Centro_Costo,
g.S10_CODUSU as CodUsuario, 
a.s10_usuario as Rco_User_Solicita_ID, d.aux_nomaux as User_Solicitay, 
f.s10_usuario as Rco_User_Origen_ID, Isnull(rtrim(g.s10_nomusu),'') as User_Origen,
a.rco_glorco as RCO_Resumen, a.rco_motivo as Rco_Motivo,
a.rco_sitrco as Rco_Situacion_Aprobado_ID, 
(Case a.rco_sitrco When '1' Then 'PENDIENTE'
                   When '2' Then 'APROBADO'
                   When '3' Then 'RECHAZADO'
                   Else 'NO DEFINIDO' End) as Rco_Situacion_Aprobado,
(Case a.rco_priori When '1' Then 'MUY ALTA'
                   When '2' Then 'ALTA'
                   When '3' Then 'MEDIA'
                   When '4' Then 'BAJA'
                   Else 'NO DEFINIDO' End) as Rco_Prioridad,
Isnull(a.rco_numpcn,'') as Rco_PCN,
a.dis_coddis as Rco_Disciplina_ID, e.Dis_DesLar as Disciplina,
(Case a.rco_rembls When '0' Then 'NO' 
                   When '1' Then 'SI' 
                   Else '   ' End) as Rco_Reembolso,
(Case a.rco_presup When '0' Then 'NO' 
                   When '1' Then 'SI' 
                   Else '   ' End) as Rco_Presupuesto,
a.rco_9digit as Rco_9_Digitos,
a.rco_codalt as Rco_Cod_Alterno,
a.rco_usucre as Rco_User_Creacion, a.rco_feccre as Rco_Fecha_Creacion,
a.rco_codusu as Rco_User_Actualiza, a.rco_fecact as Rco_Fecha_Actualiza,
Isnull(a.rco_obspri,'') as Rco_Justificacion,
a.rco_indval as RCO_Categorizado,
(Case a.rco_procur When '0' Then '       ' 
                   When '1' Then 'Admin  ' 
                   When '2' Then 'Procura' 
                   Else '       '  End) as Rco_Procura,
Isnull(a.rco_procur,'0') as Rco_Procura_ID,
isnull(a.rco_flgcom,'1') as RCO_FlgCompra_ID,
(Case isnull(a.rco_flgcom,'0') When '1' Then 'Genera Compra' 
                   When '2' Then 'No Genera Compra' 
                   Else 'No Identificado'  End) as Rco_FlgCompra,
isnull(a.rco_flgate,'0') as RCO_FlgAtencion_ID,
(Case isnull(a.rco_flgate,'0') When '0' Then 'Pendiente Atencion' 
                   When '1' Then 'Atendido por Almacen' 
                   When '2' Then 'Atendido por Certificado'                    
                   When '3' Then 'No Atender' 
                   When '4' Then 'Atendido con OC Manual'
                   Else 'No Identificado'  End) as Rco_FlgAtencion,
isnull(a.rco_jusate,'') as RCO_Justificacion_ATE,
isnull(a.rco_flgmig,'0') as RCO_MigracionID,
(Case isnull(a.rco_procur,'0') 
      When '2' Then 'PRO' 
      Else 'ADM'  End) as Rco_Area,
a.rco_tiprco as Rco_Tipo_Requisicion_ID,
h.tir_deslar as Tipo_Requisicion,
isnull(a.ocm_corocm,'') as Rco_Orden_Compra,
( isnull(j.aux_codaux,'') + (case when j.aux_codaux is null then '' else '-' end) + isnull(j.aux_nomaux,'') ) as Rco_Proveedor_OC,
Isnull(a.rco_numsol,'') as Rco_Solicitud, isnull(a.rco_monpre,'') as Rco_Moneda_ID_PRE, Isnull(k.TMO_DESLAR,'') as RCO_Moneda_PRE, Isnull(a.rco_imppre,0) as RCO_Importe_PRE 
From Requerimiento_Compra_Rco A
Left Join Unidad_Negocio_Ung B on a.cia_codcia=b.cia_codcia and a.ung_codung=b.ung_codung
Left Join Centro_Costo_Cco C on a.cia_codcia=c.cia_codcia and a.cco_codcco=c.cco_codcco
Left Join Auxiliares_AUX D on a.cia_codcia=d.cia_codcia and a.s10_usuario=d.aux_codaux
Left Join DISCIPLINAS_DIS E on a.cia_codcia=e.cia_codcia and a.dis_coddis=e.dis_coddis
Left Join APROBAC_REQCOM_APROBACIONES_ARA F On a.cia_codcia=f.cia_codcia and a.suc_codsuc=f.suc_codsuc and a.rco_numrco=f.rco_numrco and f.anm_codanm='0'
Left Join sys_tabla_usuarios_s10 G on f.s10_usuario=g.s10_usuario
Left Join Tipo_Requisicion_TIR H on a.rco_tiprco=h.rco_tiprco and a.cia_codcia=h.cia_codcia
Left Join ORDEN_COMPRA_OCC I on a.cia_codcia=i.CIA_CODCIA and a.suc_codsuc=i.suc_codsuc and a.ocm_corocm=i.ocm_corocm
Left Join AUXILIARES_AUX J on i.cia_codcia=j.CIA_CODCIA and i.aux_codaux=j.AUX_CODAUX
Left Join TIPO_DE_MONEDA_TMO K on a.rco_monpre=k.TMO_CODTMO
Where 
a.cia_codcia = 1 and a.suc_codsuc =1 And a.ano_codano=2022 AND a.mes_codmes=10  AND A.rco_numrco LIKE'%445%'--and g.S10_CODUSU='ALCAH2'
ORDER BY A.rco_feccre DESC
/*
Exec PA_HD_WEB_RQ_Consulta_Cabecera @p_CodCia='01', @p_CodSuc='01', @p_NumRQ='RQ06831502'
*/

Select Rco_obscie,*from  Requerimiento_Compra_Rco A
Where Cast(YEAR(A.rco_fecreg) as char(4))+ Substring('0'+ltrim(Cast(MONTH(A.rco_fecreg)as char(2))),len(ltrim(Cast(MONTH(A.rco_fecreg)as char(2)))),2)='202209'
ORDER BY A.rco_fecreg DESC


Select cia_codcia,
       suc_codsuc,
	   rco_numrco,
	   tin_codtin,
	   adi_codadi
	   rco_sitrco,
	   rco_sitlog,
	   ano_codano,
	   mes_codmes,
	   rco_indest,
       rco_feccre,
	   rco_usucre,
	   rco_fecact,
	   rco_codusu,
	   ung_codung,
	   rco_indcie,
	   rco_indval,
	   dis_coddis,
	   rco_rembls,
	   rco_presup,
	   rco_priori,
	   rco_motivo
from  Requerimiento_Compra_Rco
Where cia_codcia=1 AND suc_codsuc=1 AND ano_codano=2022 AND mes_codmes=10

ORDER BY rco_fecact DESC
GO
--Store Registrar en Requerimiento_Compra_Rco
ALTER PROCEDURE PA_HD_WEB_RQ_Registra_Cabecera 
       @cia_codcia char(2),@suc_codsuc char(2),@rco_numrco char(10),@tin_codtin char(2),  @adi_codadi char(2),@s10_usuario varchar(30),@rco_motivo varchar(200),@cco_codcco char(6), @rco_sitrco char(1),@rco_sitlog char(1),@ano_codano char(4),@mes_codmes char(2),  @rco_indest char(1),
       @rco_usucre varchar(30),@rco_codusu varchar(30),@ung_codung char(2),@rco_indcie smallint,  @rco_indval smallint,  @rco_rembls char(1),  @rco_presup char(1), @rco_priori char(1),@rco_tiprco char(1)
AS
Insert into Requerimiento_Compra_Rco(cia_codcia,suc_codsuc,rco_numrco,tin_codtin,rco_fecreg,rco_fecsug,adi_codadi,s10_usuario,rco_motivo,rco_glorco,cco_codcco,
rco_sitrco,rco_sitlog,ano_codano,mes_codmes,usu_codapr,rco_fecapr,rco_gloapr,rco_indest,rco_feccre,rco_usucre,rco_fecact,rco_codusu,ung_codung,
rco_indcie,rco_obscie,rco_indval,rco_numpcn,dis_coddis,rco_rembls,rco_presup,rco_9digit,rco_priori,rco_codalt,rco_obspri,rco_rutdoc,rco_fecprg,--4
rco_procur,  rco_tiprco,ocm_corocm,tmo_codtmo,rco_fecent,rco_impser,rco_flgcom,rco_flgate,rco_jusate,rco_flgmig,rco_imppor,rco_hito01,cpa_codcpa,--13
rco_imprec,rco_impfac,rco_numsol,rco_monpre,rco_imppre,rco_sitctb,rco_ajufac,rco_impcfm,rco_feinre,rco_fefire,rco_clfprv,rco_gloclf,rco_ultcer,--13  total 32 Campos Res
rco_feaclf,rco_usaclf)
Values(@cia_codcia,@suc_codsuc,@rco_numrco,@tin_codtin,NULL,NULL,@adi_codadi,@s10_usuario,@rco_motivo,NULL,@cco_codcco,@rco_sitrco,@rco_sitlog,@ano_codano,@mes_codmes,NULL,NULL,NULL,@rco_indest,
       GETDATE(),@rco_usucre,GETDATE(),@rco_codusu,@ung_codung,@rco_indcie,NULL,@rco_indval,NULL,NULL,@rco_rembls,@rco_presup,NULL,@rco_priori,NULL,NULL,
	   NULL,NULL,NULL,@rco_tiprco,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL)

INSERT INTO REQUERIMIENTO_COMPRA_RCD VALUES(@cia_codcia,@suc_codsuc,@rco_numrco,)
--VER CAMPOS NO NULOS -PARA CREAR MODELO DE REGISTRO EN WEB APP
Select cia_codcia,suc_codsuc,rco_numrco,tin_codtin,adi_codadi,rco_sitrco,rco_sitlog,ano_codano,mes_codmes,rco_indest,
       rco_feccre,rco_usucre,rco_fecact,rco_codusu,ung_codung,rco_indcie,rco_indval,rco_rembls,rco_presup,rco_priori
	   from Requerimiento_Compra_Rco Where ano_codano=2022 ORDER BY rco_feccre desc
GO
Select cia_codcia,
       suc_codsuc,
	   rco_numrco,
	   tin_codtin,
	   adi_codadi,
	   rco_sitrco,
	   rco_sitlog,
	   ano_codano,
	   mes_codmes,
	   rco_indest,
	   rco_usucre,
	   rco_codusu,
	   ung_codung,
	   rco_indcie,
	   rco_indval,
	   rco_rembls,
	   rco_presup,
	   rco_priori
	   from Requerimiento_Compra_Rco 
	   Where ano_codano=2022 ORDER BY rco_feccre desc

--EJECUTA EL SP
EXEC PA_HD_WEB_RQ_Registra_Cabecera '01','01','RQ47122020','01','','','Prueba HDSOFT 20221214','15667','2','1','2022','11','1','OSIS','OSIS','11',0,1,'1','1','3','1'

SELECT*FROM TIPO_REQUISICION_TIR
SELECT*FROM SYS_TABLA_USUARIOS_S10 WHERE S10_INDEST=1
SELECT*FROM AspNetUsers
SELECT A.rco_tiprco,*FROM REQUERIMIENTO_COMPRA_RCO A ORDER BY A.rco_fecreg DESC
GO
--STORE PARA CREAR USUARIOS
CREATE PROCEDURE PA_HD_WEB_Registra_Usuario_NET @Nombres varchar(30),@Codigo char(8),@Psd varchar(30)
AS
INSERT INTO AspNetUsers(Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount)
VALUES(NULL,@Nombres,Upper(@Nombres),@Codigo,Upper(@Codigo),1,PWDENCRYPT(@Psd),CRYPT_GEN_RANDOM(16),CRYPT_GEN_RANDOM(16),NULL,0,0,NULL,1,0)
GO
INSERT INTO AspNetUsers(Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount)
VALUES(3,'osis',Upper('osis'),'osis',Upper('osis'),1,'rriosis','R7THS4OTMYUBJW7G2ARQZLLB'+Cast(RAND() as char(8)) , '64a9d82b-e0f6-4c2d-8099-9fbe'+Cast(RAND() as char(8)) ,NULL,0,0,NULL,1,0)

SELECT Order,*FROM AspNetUsers
SELECT*FROM SYS_TABLA_USUARIOS_S10 WHERE S10_USUARIO ='LUNAP     '
UPDATE AspNetUsers SET ActivePeriod = @periodo WHERE Email = @CodUser
SELECT ActivePeriod FROM AspNetUsers WHERE Email = @CodUser

SELECT A.rco_presup,A.rco_rembls,* FROM REQUERIMIENTO_COMPRA_RCO A  where tin_codtin='01' ORDER BY A.rco_feccre DESC
SELECT*FROM V_USUARIOS_SISTEMA
SELECT*FROM UNIDAD_NEGOCIO_UNG

SELECT*
--DELETE
FROM AspNetUsers where id ='3'
UPDATE AspNetUsers SET Id ='5639c180-f08d-43bc-8881-00e793a99716' Where Id='3'


--QUERY PARA View Listar en HDProjectWeb- RQCompra 24-11-2022 SNarvasta
SELECT cia_codcia,suc_codsuc,rco_numrco,tin_codtin,rco_fecreg,rco_fecsug,adi_codadi,s10_usuario,rco_motivo,rco_glorco,cco_codcco,
       rco_sitrco,rco_sitlog,ano_codano,mes_codmes,usu_codapr,rco_fecapr,rco_gloapr,rco_indest,rco_feccre,rco_usucre,rco_fecact,rco_codusu,ung_codung,
       rco_indcie,rco_obscie,rco_indval,rco_numpcn,dis_coddis,rco_rembls,rco_presup,rco_9digit,rco_priori,rco_codalt,rco_obspri,rco_rutdoc,rco_fecprg,
       rco_procur,rco_tiprco,ocm_corocm,tmo_codtmo,rco_fecent,rco_impser,rco_flgcom,rco_flgate,rco_jusate,rco_flgmig,rco_imppor,rco_hito01,cpa_codcpa,
       rco_imprec,rco_impfac,rco_numsol,rco_monpre,rco_imppre,rco_sitctb,rco_ajufac,rco_impcfm,rco_feinre,rco_fefire,rco_clfprv,rco_gloclf,rco_ultcer,
       rco_feaclf,rco_usaclf
FROM REQUERIMIENTO_COMPRA_RCO
WHERE cia_codcia=1 AND suc_codsuc=1 AND mes_codmes=10 AND ano_codano ='2022'

--QUERY PARA View Insertar en HDProjectWeb RQCompra 25-11-2022 SNarvasta
Insert into Requerimiento_Compra_Rco(cia_codcia,suc_codsuc,rco_numrco,tin_codtin,rco_fecreg,rco_fecsug,adi_codadi,s10_usuario,rco_motivo,rco_glorco,cco_codcco,
rco_sitrco,rco_sitlog,ano_codano,mes_codmes,usu_codapr,rco_fecapr,rco_gloapr,rco_indest,rco_feccre,rco_usucre,rco_fecact,rco_codusu,ung_codung,
rco_indcie,rco_obscie,rco_indval,rco_numpcn,dis_coddis,rco_rembls,rco_presup,rco_9digit,rco_priori,rco_codalt,rco_obspri,rco_rutdoc,rco_fecprg,--4
rco_procur,rco_tiprco,ocm_corocm,tmo_codtmo,rco_fecent,rco_impser,rco_flgcom,rco_flgate,rco_jusate,rco_flgmig,rco_imppor,rco_hito01,cpa_codcpa,--13
rco_imprec,rco_impfac,rco_numsol,rco_monpre,rco_imppre,rco_sitctb,rco_ajufac,rco_impcfm,rco_feinre,rco_fefire,rco_clfprv,rco_gloclf,rco_ultcer,--13  total 32 Campos Res
rco_feaclf,rco_usaclf)
Values(@cia_codcia,@suc_codsuc,@rco_numrco,@tin_codtin,rco_fecreg,rco_fecsug,adi_codadi,s10_usuario,rco_motivo,rco_glorco,cco_codcco,
		@rco_sitrco,@rco_sitlog,@ano_codano,mes_codmes,usu_codapr,rco_fecapr,rco_gloapr,rco_indest,rco_feccre,rco_usucre,rco_fecact,rco_codusu,ung_codung,
        @rco_indcie,@rco_obscie,@rco_indval,rco_numpcn,dis_coddis,rco_rembls,rco_presup,rco_9digit,rco_priori,rco_codalt,rco_obspri,rco_rutdoc,rco_fecprg,
        @rco_procur,@rco_tiprco,@ocm_corocm,tmo_codtmo,rco_fecent,rco_impser,rco_flgcom,rco_flgate,rco_jusate,rco_flgmig,rco_imppor,rco_hito01,cpa_codcpa,
        @rco_imprec,@rco_impfac,@rco_numsol,rco_monpre,rco_imppre,rco_sitctb,rco_ajufac,rco_impcfm,rco_feinre,rco_fefire,rco_clfprv,rco_gloclf,rco_ultcer,
	    @rco_feaclf,@rco_usaclf)

GO
---EJECUTA QUERY INSERT PARA VIEW CREAR EN HD PROJECT WEB
EXEC 
 PA_HD_WEB_RQ_Registra_Cabecera @cia_codcia = @cia_codcia, @suc_codsuc = @suc_codsuc, @rco_numrco = @rco_numrco, @tin_codtin = @tin_codtin
  ,@s10_usuario = @s10_usuario, @rco_motivo = @rco_motivo, @cco_codcco = @cco_codcco,@rco_sitrco = @rco_sitrco, @rco_sitlog = @rco_sitlog
  ,@ano_codano = @ano_codano, @mes_codmes = @mes_codmes, @rco_indest = @rco_indest, @rco_usucre = @rco_usucre , @rco_tiprco = @rco_tiprco
  ,@rco_codusu = @rco_codusu, @ung_codung = @ung_codung, @rco_indcie = @rco_indcie, @rco_indval = @rco_indval , @rco_priori = @rco_priori
  ,@rco_rembls = @rco_rembls, @rco_presup = @rco_presup, @adi_codadi = @adi_codadi


  --********** QUERY PARA VISTA EDITAR EN RQCOMPRAS WEB
   SELECT  A.rco_numrco,A.rco_fecreg ,A.rco_motivo,A.ung_codung,A.cco_codcco ,D.CCO_DESLAR as cco_deslar,A.dis_coddis,A.rco_sitrco,A.rco_priori,
	A.rco_obspri,A.rco_rembls,A.rco_presup,A.rco_indest,A.rco_tiprco,Cast(A.rco_indval as bit)as rco_indval,B.DIS_DESLAR as dis_deslar,A.s10_usuario,A.rco_glorco,
	Cast(Isnull((
               Select count(*) as CCC_TotFil From CUADRO_COMPARATIVO_COMPRAS_CCC X 
               Left Join Solicitud_Compra_Scc Y on x.cia_codcia=y.cia_codcia and x.suc_codsuc=y.suc_codsuc and x.scc_numscc=y.scc_numscc 
               Where x.cia_codcia=a.cia_codcia and x.suc_codsuc=a.suc_codsuc and y.rco_numrco=a.rco_numrco and y.scc_indest='1' 
                 and isnull(x.ccc_indoky,'0')='1'
             ),0)as bit) as ccc_numero,
       Isnull((Select Top 1 x.ocm_corocm From Orden_Compra_Occ X 
                Left Join Solicitud_Compra_Scc Y on x.cia_codcia=y.cia_codcia and x.suc_codsuc=y.suc_codsuc and x.scc_numscc=y.scc_numscc 
                Where x.cia_codcia=a.cia_codcia and x.suc_codsuc=a.suc_codsuc and y.rco_numrco=a.rco_numrco and x.occ_indest='1' and y.scc_indest='1' 
           ),'') as occ_numero
    FROM REQUERIMIENTO_COMPRA_RCO A  
	LEFT JOIN DISCIPLINAS_DIS     B ON A.cia_codcia=B.CIA_CODCIA AND A.dis_coddis=B.DIS_CODDIS
	Left Join Unidad_Negocio_Ung  C on a.cia_codcia=C.cia_codcia and a.ung_codung=C.ung_codung
	LEFT JOIN CENTRO_COSTO_CCO D ON A.cia_codcia=D.CIA_CODCIA AND A.cco_codcco=D.CCO_CODCCO
	WHERE rco_numrco = 'CC04782200'

	SELECT CIA_CODCIA,CCO_CODCCO,CCO_DESLAR,* FROM CENTRO_COSTO_CCO WHERE CIA_CODCIA=01 AND CCO_INDEST=1 AND CCO_INDCOS=0
	SELECT * FROM DISCIPLINAS_DIS WHERE DIS_INDEST=1 AND CIA_CODCIA=01

	-- QUERY PARA TABLA DETALLES EN VISTA EDITAR/CREAR
	SELECT B.rcd_corite as item,B.prd_codprd as codigo,rcd_desprd as descri,rcd_glorcd as glosa,ume_codume as unidad,
	rcd_canapr as cantidad,J.AUX_CODAUX as codprov, J.AUX_NOMAUX as nomprov
	FROM REQUERIMIENTO_COMPRA_RCO A
	LEFT JOIN REQUERIMIENTO_COMPRA_RCD B ON A.cia_codcia=B.cia_codcia AND A.suc_codsuc=B.suc_codsuc AND A.rco_numrco=B.rco_numrco
	Left Join ORDEN_COMPRA_OCC I on a.cia_codcia=i.CIA_CODCIA and a.suc_codsuc=i.suc_codsuc and a.ocm_corocm=i.ocm_corocm
    Left Join AUXILIARES_AUX J on i.cia_codcia=j.CIA_CODCIA and i.aux_codaux=j.AUX_CODAUX
	WHERE A.rco_numrco = 'RQ21712204'

	SELECT*FROM PRODUCTOS_PRD WHERE prd_codprd='L205990004' 

	SELECT*FROM REQUERIMIENTO_COMPRA_RCD Where rco_numrco = 'RQ21922204'

	
