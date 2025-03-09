# **Create Empty Parent at Center**  

## **📌 Overview**  
This **Unity Editor tool** allows you to create an empty parent **at the true center of selected objects**, instead of using their **pivot points** like Unity’s default "Create Empty Parent" does. This ensures **better grouping, alignment, and scene organization** when working with multiple objects.  

---

## **📽️ Video Tutorial**  
🎥 **Watch the tool in action!** Learn how to use it in **this step-by-step tutorial:**  
📌 **[YouTube Tutorial](https://youtu.be/UWmzkw4uzOo)**  

---

## **🚀 Why Use This?**  
- **Default Unity behavior** creates the parent using the **pivot points** of selected objects, which may not always be ideal.  
- **This tool calculates the true center** based on the **bounding box of all selected objects** instead.  
- **Maintains object hierarchy** while allowing precise organization.  
- **Automatically renames and selects the new parent**, so you can quickly edit it.  

---

## **📥 Installation**  
### **🔹 Option 1: Import the Unity Package (Recommended)**  
1. Download the **`CreateParentAtCenter.unitypackage`** from the repository.  
2. In Unity, go to **`Assets` → `Import Package` → `Custom Package...`**.  
3. Select **`CreateParentAtCenter.unitypackage`** and click **Import**.  

### **🔹 Option 2: Manual Installation**  
1. Download **[`CreateEmptyParentAtCenter.cs`](https://github.com/Shripad-S-Agashe/UnityTools/blob/Scene_Organization_Tools/Editor/CreateParentAtCenter.cs)**.  
2. Place it inside your Unity project’s **`Assets/Editor/`** folder.  
3. Open Unity, and the tool will be available in **GameObject → Create Empty Parent at Center**.  

---

## **🛠️ How It Works**  
1. **Select multiple objects** in the Hierarchy.  
2. Click **GameObject → Create Empty Parent at Center** or use a custom shortcut (if assigned).  
3. A **new empty parent** is created at the **calculated center** of the selected objects.  
4. The selected objects are **automatically reparented** under the new empty GameObject.  
5. The tool **automatically highlights and renames the new parent**, making it easy to edit.  

---

## **📌 Features**  
✔️ **Creates an empty parent using object bounds, not pivots.**  
✔️ **Maintains hierarchy & keeps relative positions intact.**  
✔️ **Automatically selects and renames the new parent** for quick editing.  
✔️ **Works with all object types**, including meshes, UI elements, and non-mesh objects.  

---

## **🎯 Usage Example**  
Imagine you’re working with multiple **props, environment assets, or UI elements**. Instead of manually adjusting a new empty parent:  
✅ **Select objects** → Click **"Create Empty Parent at Center"** → **Done!**  

The **new parent is now at the true geometric center** of the selected objects, making it **easier to manipulate and align them**.  

---

## **📜 License**  
This tool is **free & open-source** under the **MIT License**.  
👉 Feel free to **use, modify, and contribute**!  

---

## **🤝 Contributing**  
🚀 Want to improve this tool? Open an **Issue** or submit a **Pull Request** here:  
🔗 **[GitHub Issues & PRs](https://github.com/Shripad-S-Agashe/UnityTools/issues)**  

---

## **🌍 More from Me**  
🔗 **Website:** [https://www.shripadagashe.com/](https://www.shripadagashe.com/)  

🚀 **Happy Unity development!** 🎮  
