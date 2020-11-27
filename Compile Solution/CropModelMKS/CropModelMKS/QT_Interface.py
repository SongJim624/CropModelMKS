import sys
import PyQt5.QtCore
from PyQt5.QtWidgets import QApplication, QWidget, QMainWindow
import Platform

if __name__ == '__main__':
# application
    PyQt5.QtCore.QCoreApplication.setAttribute(PyQt5.QtCore.Qt.AA_EnableHighDpiScaling)
    app = QApplication(sys.argv)

#main window
    platform = Platform.Platform()

#    window.resize(300, 400)
    platform.window.setWindowTitle("Micro Kernel System for Crop Model")
    platform.window.show()

#main loop    
    sys.exit(app.exec_())