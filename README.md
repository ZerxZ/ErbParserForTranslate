### 高性能的开源Era字典工具
我也不想造轮子啊！我也想用现成的轮子改一改就用啊！
但是找不到，找不到这种一键提取所有era文本并替换的开源轮子，于是我上了。
因为我还是个EraBasic初学者，可能会有许多提取和替换上的错漏，希望大家能帮我测试修正，提供反馈！
目前我使用EraOCG2作为测试样本，表现良好，提取和汉化分别只需要1秒和2秒，暂未发现错漏之处。需要更多更大的测试样本！
有什么需求也欢迎提出，我会加入~~人才库~~需求池的！
### 目前支持
- [√] **提取文本**：从游戏目录提取未翻译的字典；
- [√] **导入译文**：使用已翻译的字典汉化游戏；
- [√] **快速迁移**：对照原版游戏和已汉化游戏，提取出已翻译的字典。无论处于什么汉化阶段，都能使用这个功能快速迁移工作流；
- [√] **开放配置**：用户可以在config.json下修改设置。当然直接改代码也很方便，我几乎三五行代码就有一行注释；
### TODO
- [x] **版本更新**：从新版本游戏中提取增删改的条目，插入到原字典中；
### 需求池
- [x] **机器翻译**：在配置文件里配置Token来批量机翻；
- [x] **黑の名单**：在配置文件里配置某些文件、指定词条不会被提取和翻译；
- [x] **快速填充**：遍历未翻译的条目，然后查找相同的已翻译的条目进行填充；
- [x] **用户界面**：我打Paratranz？诶……真的假的……；
### 懒得做的
- [x] **ERB行末注释**：对，我做了CSV行末注释，虽然做起来不麻烦，但就是不想做；
- [x] **花括号合并多行代码**：似乎没有游戏使用，就当这个特性不存在吧，虽然做起来不麻烦；
- [x] **同名ERB和ERH导致键值冲突**；
