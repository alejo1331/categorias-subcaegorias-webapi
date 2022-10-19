from fabric.api import *
from fabric.contrib import files

path_base = "/govco/"
path_service = "/govco/services/"

def create_token_aws(token=""):
    run('aws ecr get-login-password --region us-east-1 | docker login --username AWS --password-stdin ' + token)

def init_config():
    if files.exists(path_service):
        print ("Configuración Inicial ya existe")
    else:
        sudo("mkdir -p " + path_service)
        sudo("chown -hvR centos " + path_base)

def init_network_govco():
    run("docker network create NETWORK_GOVCO_INTERNO || true")

def validate_create_folder(foldername=""):
    ruta = path_service + foldername
    if files.exists(ruta):
        print ("Existe Folder: " + ruta)
    else:
        print ("Creando Folder: " + ruta)
        run('mkdir -p ' + ruta)
        print ("Folder " + ruta +  " Creado")

#  __   __ ___ 
#  \ \ / /|_  )
#   \ V /  / / 
#    \_/  /___|
#

def validate_dockerfile_env(foldername="", compose=""):
    ruta = path_service + foldername
    dockerfile = "docker-compose-" + compose + ".yml"
    archivo = '{}{}'.format(ruta, "/" + dockerfile)
    print ("Actualizando Archivo: " + archivo)
    if files.exists(archivo):
        print ("Actualizando Archivo de Configuración")
        put(dockerfile, ruta)
        run ('ls -l ' + ruta)
        print ("Archivos Actualizados")
    else:
        print ("Copiando Archivo de Configuración ... ")
        put(dockerfile, ruta)
        run ('ls -l ' + ruta)
        print ("Archivo Copiado")

def compose_down_env(foldername="", compose=""):
    ruta = path_service + foldername
    dockerfile = "docker-compose-" + compose + ".yml"
    archivo = '{}{}'.format(ruta, "/" + dockerfile)
    if files.exists(archivo):
        print ("Existe Archivo: " + archivo)
        with cd(ruta):
            try:
                run('docker-compose -f ' + dockerfile + ' down --rmi all')
            except Exception:
                print (Exception)
    else:
        print ("No Existe Archivo: " + archivo)

def compose_up_env(foldername="", compose=""):
    ruta = path_service + foldername
    dockerfile = "docker-compose-" + compose + ".yml"
    archivo = '{}{}'.format(ruta, "/" + dockerfile)
    if files.exists(archivo):
        print ("Existe Archivo: " + archivo)
        with cd(ruta):
            try:
                run('docker-compose -f ' + dockerfile + ' up -d')
            except Exception:
                print (Exception)
    else:
        print ("No Existe Archivo: " + archivo)