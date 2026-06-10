from import_export import resources, fields
from gestion_abierta import models as m_gestion_abierta
from usuario import models as m_usuario
from import_export.widgets import ForeignKeyWidget



class InformeResource(resources.ModelResource):
    
    usuario = fields.Field(
        column_name='usuario',
        attribute='usuario',
        widget=ForeignKeyWidget(m_usuario.UsuarioGestionAbierta, 'correo'))

    class Meta:
        model  = m_gestion_abierta.Informe

        export_order = ("id",'titulo','descripcion','usuario','evidencia','url_evidencia','fecha_informe','estado')
        import_id_fields = ('titulo','descripcion','usuario','evidencia','url_evidencia','fecha_informe','estado')
        fields = ("id",'titulo','descripcion','usuario','evidencia','url_evidencia','fecha_informe','estado' )