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


def validate_update_all_file_services(foldername=""):
    ruta = path_service + foldername
    archivo = '{}{}'.format(ruta, "/docker-compose.yml")
    if files.exists(archivo):
        print ("Actualizando Archivo de Configuración")
        put("docker-compose.yml", ruta)
        put("docker-compose-develop.yml", ruta)
        run ('ls -l ' + ruta)
        print ("Archivos Actualizados")
    else:
        print ("Copiando Archivo de Configuración ... ")
        put("docker-compose.yml", ruta)
        put("docker-compose-develop.yml", ruta)
        run ('ls -l ' + ruta)
        print ("Archivo Copiado")

def validate_update_all_file_services_2(foldername=""):
    ruta = path_service + foldername
    archivo = '{}{}'.format(ruta, "/docker-compose.yml")
    if files.exists(archivo):
        print ("Actualizando Archivo de Configuración")
        put("docker-compose.yml", ruta)
        put("docker-compose-stage.yml", ruta)
        run ('ls -l ' + ruta)
        print ("Archivos Actualizados")
    else:
        print ("Copiando Archivo de Configuración ... ")
        put("docker-compose.yml", ruta)
        put("docker-compose-stage.yml", ruta)
        run ('ls -l ' + ruta)
        print ("Archivo Copiado")


###########
# Develop #
###########

def compose_down_develop(foldername=""):
    ruta = path_service + foldername
    archivo = '{}{}'.format(ruta, "/docker-compose-develop.yml")
    if files.exists(archivo):
        print ("Existe Archivo: " + archivo)
        with cd(ruta):
            try:
                run('docker-compose -f docker-compose-develop.yml down --rmi all')
            except Exception:
                print (Exception)
    else:
        print ("No Existe Archivo: " + archivo)


def compose_up_develop(foldername=""):
    ruta = path_service + foldername
    archivo = '{}{}'.format(ruta, "/docker-compose-develop.yml")
    if files.exists(archivo):
        print ("Existe Archivo: " + archivo)
        with cd(ruta):
            try:
                run('docker-compose -f docker-compose-develop.yml up -d')
            except Exception:
                print (Exception)
    else:
        print ("No Existe Archivo: " + archivo)

###########
# Release #
###########

def compose_down_release(foldername=""):
    ruta = path_service + foldername
    archivo = '{}{}'.format(ruta, "/docker-compose-release.yml")
    if files.exists(archivo):
        print ("Existe Archivo: " + archivo)
        with cd(ruta):
            try:
                run('docker-compose -f docker-compose-release.yml down')
            except Exception:
                print (Exception)
    else:
        print ("No Existe Archivo: " + archivo)


def compose_up_release(foldername=""):
    ruta = path_service + foldername
    archivo = '{}{}'.format(ruta, "/docker-compose-release.yml")
    if files.exists(archivo):
        print ("Existe Archivo: " + archivo)
        with cd(ruta):
            try:
                run('docker-compose -f docker-compose-release.yml up -d')
            except Exception:
                print (Exception)
    else:
        print ("No Existe Archivo: " + archivo)

###########
# Master #
###########

def compose_down_master(foldername=""):
    ruta = path_service + foldername
    archivo = '{}{}'.format(ruta, "/docker-compose.yml")
    if files.exists(archivo):
        print ("Existe Archivo: " + archivo)
        with cd(ruta):
            try:
                run('docker-compose down')
            except Exception:
                print (Exception)
    else:
        print ("No Existe Archivo: " + archivo)


def compose_up_master(foldername=""):
    ruta = path_service + foldername
    archivo = '{}{}'.format(ruta, "/docker-compose.yml")
    if files.exists(archivo):
        print ("Existe Archivo: " + archivo)
        with cd(ruta):
            try:
                run('docker-compose up -d')
            except Exception:
                print (Exception)
    else:
        print ("No Existe Archivo: " + archivo)

###########
# stage #
###########

def compose_down_stage(foldername=""):
    ruta = path_service + foldername
    archivo = '{}{}'.format(ruta, "/docker-compose-stage.yml")
    if files.exists(archivo):
        print ("Existe Archivo: " + archivo)
        with cd(ruta):
            try:
                run('docker-compose -f docker-compose-stage.yml down --rmi all')
            except Exception:
                print (Exception)
    else:
        print ("No Existe Archivo: " + archivo)


def compose_up_stage(foldername=""):
    ruta = path_service + foldername
    archivo = '{}{}'.format(ruta, "/docker-compose-stage.yml")
    if files.exists(archivo):
        print ("Existe Archivo: " + archivo)
        with cd(ruta):
            try:
                run('docker-compose -f docker-compose-stage.yml up -d')
            except Exception:
                print (Exception)
    else:
        print ("No Existe Archivo: " + archivo)  