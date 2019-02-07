import { PLATFORM } from 'aurelia-pal';

export class app {
    constructor() {
    }

    configureRouter(config, router) {
        config.options.pushState = true;
        config.title = 'TodoMVC'
        config.map([
            { route: ['', ':filter'], moduleId: PLATFORM.moduleName('todos') }
        ]);

        this.router = router;
    }
}
