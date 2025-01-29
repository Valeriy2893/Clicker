Используется:

0) ООП, SOLID, DRY, KISS, YAGNI;
1) Mvp (passive view, для разделение на слои);
2) Entry Point (для контроля порядка инициализации объектов);
3) Factory (для создания кнопок и животных);
4) Strategy (для подмены модели или вью, в случае необходимости);
5) UniRx (чаще всего ReadOnlyReactiveProperty для удобного обновления вью после изменения данных в модели);
6) ScriptableObject (для удобного изменения первоначальных настроек для гейдизайнера);
7) Сцена Bootstrap (для подгрузки сервисов);
8) Pool объектов (для вылетающего текста, оптимизация производительности);
9) DOTween (для анимации вылетающего текста);
10) Assembly Definitions (для инкапсуляции модулей);

Не сделан акцент:
1) На оптимизацию (не отключены raycast Target, нет sprite-атласов, почти весь UI сразу на сцене и т.д.);
2) На визуальной части (спрайты, шейдеры и т.д.);
3) На размере билда;

Не используется:
1) DI контейнер;
2) UniTask;
3) Addressables;
4) Система сохранения;
5) Механика намерено была взята самая простая, чтобы сделать акцент именно на архитектуре проекта;

Игра представляет из себя классический кликер:

1) При старте мы видим:
   
    а) по центру животное, которое мы кликаем;
  
    б) Справа панель для прокачки (клик, клик в секунду и т.д);
  
    в) Снизу размещены монеты, которые мы может потратить для улучшения;
  
    г) Сверху слайдер, который при клике заполняется на столько на сколько "сильным" был клик;
  
    д) Также сверху размещён номер уровеня;
 
    е) Играет фоновая музыка (которую можно изменить в конфиге);
  
2) Когда мы кликаем по животному:
   
    а) Воспроизводится звук клика (который без труда можно заменить на подходящий или подходящие, с помощью SO);
  
    б) Воспроизводится анимация текущего животного (она случайная из того пула, который также можно изменить в SO);
  
    в) Появляется и вылетает текст в месте нажатия (который отображает сколько монет будет начислено), используется пулл для этого, текст также можно изменить в префабе;
  
    г) Воспроизводится fx клика (который можно изменить по своему усмотрению);
  
3) Справа находится магазин:
   
     а) Количество "кнопок" для улучшения в магазине можно легко менять;
   
     б) Каждую "кнопку" можно подробно настроить (иконка, имя, префаб, порядок отрисовки в магазине, значение по умолчанию, цена по умолчанию, множитель цены и др);
   
     в) Состояние "кнопок" меняется в зависимости от количества монет в данный момент;
   
     г) Апгрейд значений кнопок влияет на то сколько монет мы будем получать в результате клика по животному;
   
4) Каждый раз когда полоска сверху заполняется уровень повышается:
   
    а) Срабатывает fx смены (который можно заменить при желании);
  
    б) Меняется животное на другое (сначала по порядку, как все уникальные закончились, выбирается рандомно, количество без труда можно изменить);
  
    в) Количество опыта для нового уровня можно настроить (когда список заканчивается, последнее количество опыта зацикливается);
  
    г) Воспроизводится звук смены уровня ( можно изменить в SO);

Видео геймплея прилагается;
