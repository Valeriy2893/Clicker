Используется:

0) ООП, SOLID, DRY, KISS, YAGNI
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

Не используется DI контейнер и UniTask, Addressables, и система сохранения;
