import clr
import xml.dom.minidom

status = clr.AddReference("Core")
import CropModelMKS

s = CropModelMKS.Simulator()

doc = xml.dom.minidom.parse("C:\\Users\\Song Jim\\source\\repos\\QT Interface\\QT Interface\\Projects\\A True\\Parameters\\Climate-Light.CLI.XML").documentElement
parameter = CropModelMKS.Parameter(doc)

simulator = CropModelMKS.ISimulator(CropModelMKS.Simulator())
simulator.Configurate("C:\\Users\\Song Jim\\source\\repos\\QT Interface\\QT Interface\\Projects\\A True\\project.XML")
simulator.simulate()