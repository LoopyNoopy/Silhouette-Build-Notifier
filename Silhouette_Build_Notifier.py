from functools import partial
import os, time, datetime, tkinter
from win10toast import ToastNotifier
toaster = ToastNotifier()

mydate = datetime.datetime.now()

def showNotification():
    toaster.show_toast("Silhouette New Build detecter","New build is avaliable in b9.0.5 - SS4.3.301.W6B.exe", icon_path="silhouette_logo.ico", threaded=True)
    return()

def getMonthBranches():
    branches = os.listdir("Z://2019//{}".format(mydate.strftime("%B")))
    for folder in branches:
        if folder[0] == ".":
            branches.remove(folder)
    return(branches)

def createBranchChkBox(folders):
    checkVar = []
    for folder in folders:
        #checkVar.append(IntVar())
        folder = tkinter.Checkbutton(app, text = folder, onvalue = 1, offvalue = 0, height=5, width = 20)
    return()

class App():
    def __init__(self):
       branchesVar = []
       self.root = tkinter.Tk()
       self.root.configure(background = "white")
       self.root.title("Silhouette Build Notifier")
       self.root.wm_iconbitmap('silhouette_logo.ico')

       branches = os.listdir("Z://2019//{}".format(mydate.strftime("%B")))
       for folder in branches:
        if folder[0] == ".":
            branches.remove(folder)

       lTitle = tkinter.Label(self.root, text = "Silhouette R&T Build Notifier", background ="white", font=("Segoe UI", 14))
       ldate = tkinter.Label(self.root, text = "{0} - {1}".format(mydate.strftime("%B"), mydate.year), background ="white", font=("Segoe UI", 12))
       bQuit = tkinter.Button(self.root, text = 'Close', background = "#d06a4e", foreground = "white", activebackground = "#BA4F31", activeforeground = "white", highlightthickness = 0, bd = 0, command=self.quit, font=("Segoe UI", 12))
       
       lTitle.grid(pady = 5, padx = 10, columnspan = 3)
       ldate.grid(columnspan = 3, pady = (0,15))
       
       for count, branch in enumerate(branches):
           branchesVar.append(tkinter.IntVar())
           l = tkinter.Checkbutton(self.root, text=branch, command = partial(self.printSelf,branchesVar, branches), variable=branchesVar[count], background = "white", font=("Segoe UI", 10))
           l.grid(pady = 1, padx = 10, column = 1, columnspan = 2, row = count+3, sticky = "W")
       bQuit.grid(pady = 10, padx = 10, sticky="SE", column = 2)
       self.root.mainloop()

    def printSelf(self, branchesVar, branches):
        file = open("watchlist.txt", "w+")
        for count,i in enumerate(branchesVar):
            if branchesVar[count].get() == 1:
                file.write(branches[count] + "\n")
        file.close
        return()

    def quit(self):
        self.root.destroy() 
        return()

getMonthBranches()
app = App()